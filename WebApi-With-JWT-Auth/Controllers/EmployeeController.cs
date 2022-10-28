using DAL.Models;
using IObjects.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeData.Controllers
{
    [Route("api/employee")]
    [Authorize]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IDataRepository<Employee> _employeeRepository;

        public EmployeeController(IDataRepository<Employee> EmpRepository)
        {
            _employeeRepository = EmpRepository;
        }
        [HttpGet]

        public IActionResult Get()
        {
            IEnumerable<Employee> Emp = _employeeRepository.GetAll();
            return Ok(Emp);
        }
        [HttpGet("id")]
        public IActionResult Getbyid(int id)
        {
            Employee employee = _employeeRepository.Getbyid(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }
        [HttpPost]
        public IActionResult Post(Employee employee)
        {
            _employeeRepository.Add(employee);
            return Ok(employee);
        }
        [HttpPut("id")]
        public IActionResult Put(int id, Employee employee)
        {
            Employee emptoupdate = _employeeRepository.Getbyid(id);
            _employeeRepository.Update(emptoupdate, employee);
            return NoContent();
        }
        [HttpDelete("id")]
        public IActionResult Delete(int id)
        {
            Employee employee = _employeeRepository.Getbyid(id);
            _employeeRepository.Delete(employee);
            return NoContent();

        }
    }
}
