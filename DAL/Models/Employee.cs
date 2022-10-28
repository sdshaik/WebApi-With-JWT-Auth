using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class Employee
    {
        [Key]
        public int Emp_Id { get; set; }

        public string Emp_Name { get; set; }

        public string Emp_Password { get; set; }

        public double Emp_sal { get; set; }

        public string Emp_Gender { get; set; }

        public string EMp_Email { get; set; }

        public DateTime Emp_Dob { get; set; }
    }
}
