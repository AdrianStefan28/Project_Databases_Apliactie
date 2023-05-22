using MTAApp.DataAccess.Abstractions;
using MTAApp.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTAApp.Logic
{
    public class EmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return employeeRepository.GetAll();
        }
        public Employee GetEmployee(int id)
        {
            return employeeRepository.Get(id);
        }

        public Employee AddEmployee(Employee employee)
        {
            return employeeRepository.Add(employee);
        }
        public Employee UpdateEmployee(Employee employee)
        {
            return employeeRepository.Update(employee);
        }

        public void DeleteEmployee(int id)
        {
            employeeRepository.Remove(id);
        }
        public double CalculateEmployeeTotalPay(Employee employee)
        {
            return (double)(employee.ContractDuration * employee.Salary);
        }
        public string GetEmployeeType(Employee employee)
        {
            return employee.Type;
        }
        public void SetEmployeeSalary(Employee employee, double newSalary)
        {
            employee.Salary = newSalary;
        }
        public Employee GetEmployeeByType(string Type)
        {
            return employeeRepository.GetEmployeeByType(Type);
        }
        public Employee GetEmployeeByName(string FirstName, string LastName)
        {
            return employeeRepository.GetEmployeeByName(FirstName, LastName);
        }
    }
}
