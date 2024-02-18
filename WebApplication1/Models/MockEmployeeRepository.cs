
using EmployeeManagement.Models;

namespace WebApplication1.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {

        private List<Employee> _employeeList;

        public MockEmployeeRepository()
        {

            _employeeList = new List<Employee>()
            {
    new Employee() { Id = 1, Name = "Theja Kumar", Email = "theja@devcare.com", Department = Dept.IT },
    new Employee() { Id = 2, Name = "Kiran", Email = "kiran@devcare.com", Department = Dept.IT },
    new Employee() { Id = 3, Name = "John Doe", Email = "john@devcare.com", Department = Dept.HR },

            };
        }

        public Employee Add(Employee employee)
        {
          employee.Id =  _employeeList.Max(e => e.Id)+1;
            _employeeList.Add(employee);
            return employee;
        }

        public Employee Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeList;
        }

        public Employee GetEmployee(int id)
        {
            return _employeeList.FirstOrDefault(e => e.Id == id);
        }

        public Employee Update(Employee employeeChanges)
        {
            throw new NotImplementedException();
        }
    }
}
