using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EmployeeData.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly Emp_Context _Context;
        public TokenController(IConfiguration configuration, Emp_Context context)
        {
            _configuration = configuration;
            _Context = context;
        }
        [HttpPost]
        public async Task<IActionResult> Post(Employee employee)
        {
            if (employee != null && employee.Emp_Name != null && employee.Emp_Password != null)
            {
                var emp = await GetEmp(employee.Emp_Name, employee.Emp_Password);
                if (emp != null)
                {
                    var Claim = new[]
                    {
                        new Claim (JwtRegisteredClaimNames.Sub,_configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                        new Claim (JwtRegisteredClaimNames.Iat,DateTime.UtcNow.ToString()),
                        new Claim ("UserId",employee.Emp_Id.ToString()),
                        new Claim ("Emp_Password",employee.Emp_Password.ToString()),
                        new Claim ("Emp_Email",employee.EMp_Email.ToString()),
                        new Claim ("Emp_Dob",employee.Emp_Dob.ToString())
                    };
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var SignIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                      Claim,
                       expires: DateTime.UtcNow.AddMinutes(10),
                       signingCredentials: SignIn);
                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest();
                }

            }
            else
            {
                return BadRequest();
            }


        }
        private async Task<Employee> GetEmp(string Emp_Name, string Password)
        {
            return await _Context.Emp.FirstOrDefaultAsync(x => x.Emp_Name == Emp_Name && x.Emp_Password == Password);
        }
    }
}
