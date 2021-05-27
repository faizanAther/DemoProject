using RestCRUDDemoService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestCRUDDemoService.EmployeeData
{
    public class SqlEmployeeData : IEmployeeData
    {
        private EmployeeContext _employeeContext;
        public SqlEmployeeData(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
        }
        public Employee AddEmployee(Employee employee)
        {
            employee.Id = Guid.NewGuid();
            _employeeContext.Employee.Add(employee);
            _employeeContext.SaveChanges();
            return employee;
        }

        public void DeleteEmployee(Employee employee)
        {
            _employeeContext.Employee.Remove(employee);
            _employeeContext.SaveChanges();
        }

        public Employee EditEmployee(Employee employee)
        {
            var existingEmployee = _employeeContext.Employee.Find(employee.Id);
            if (existingEmployee != null)
            {
                existingEmployee.Name = employee.Name;
                _employeeContext.Employee.Update(existingEmployee);
                _employeeContext.SaveChanges();
            }
            return employee;
        }

        public Employee GetEmployee(Guid id)
        {
            var employee = _employeeContext.Employee.Find(id);
            return employee;
        }

        public List<Employee> GetEmployees()
        {
            return _employeeContext.Employee.ToList();
        }
    }
}
