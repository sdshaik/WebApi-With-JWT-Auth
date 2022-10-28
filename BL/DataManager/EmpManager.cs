using DAL.Models;
using IObjects.Repository;

namespace BL.DataManager
{
    public class EmpManager : IDataRepository<Employee>
    {
        readonly Emp_Context emp_Context;
        public EmpManager(Emp_Context emp_Context)
        {
            this.emp_Context = emp_Context;
        }
        public IEnumerable<Employee> GetAll()
        {
            // return (IEnumerable<Employee>)emp_Context.employees.ToList();
            return emp_Context.Emp.ToList();
        }
        public Employee Getbyid(int id)
        {
            return (Employee)emp_Context.Emp.FirstOrDefault(x => x.Emp_Id == id);
        }
        public void Add(Employee entity)
        {
            emp_Context.Emp.Add(entity);
            emp_Context.SaveChanges();
        }
        public void Update(Employee employee, Employee entity)
        {
            employee.Emp_Name = entity.Emp_Name;
            employee.Emp_Password = entity.Emp_Password;
            employee.Emp_sal = entity.Emp_sal;
            employee.Emp_Gender = entity.Emp_Gender;
            employee.EMp_Email = entity.EMp_Email;
            employee.Emp_Dob = entity.Emp_Dob;
        }
        public void Delete(Employee employee)
        {
            emp_Context.Emp.Remove(employee);
            emp_Context.SaveChanges();
        }
    }

}
