using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Model
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeeList;

        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>()
            {
                new Employee() { Id = 1, Name = "Mary", Department = Dept.HR, Email = "mary@gmail.com"},
                new Employee() { Id = 2, Name = "Jhon", Department = Dept.IT, Email = "jhon@gmail.com"},
                new Employee() { Id = 3, Name = "Sam", Department = Dept.IT, Email = "sam@gmail.com"},

            };
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return _employeeList;   
        }

        public Employee GetEmployee(int id)
        {
            return _employeeList.FirstOrDefault(e => e.Id == id);
        }
    }
}
