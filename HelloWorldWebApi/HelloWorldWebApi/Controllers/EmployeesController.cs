using HelloWorldWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HelloWorldWebApi.Controllers
{
    public class EmployeesController : ApiController
    {
        private static IList<Employee> employees = new List<Employee>() 
        { 
            new Employee()
            {
                Id = 12345, FirstName = "John", LastName = "Human"
            },
            new Employee()
            {
                Id = 12346, FirstName = "Jane", LastName = "Public"
            },
            new Employee()
            {
                Id = 12347, FirstName = "Joseph", LastName = "Law"
            }
        };

        public IEnumerable<Employee> Get()
        {
            return employees;
        }

        public Employee Get(int id)
        {
            return employees.FirstOrDefault(e => e.Id == id);
        }

        public void Post(Employee employee)
        {
            int maxId = employees.Max(e => e.Id);
            employee.Id = maxId + 1;
            employees.Add(employee);
        }

        public void Delete(int id)
        {
            Employee employee = Get(id);
            employees.Remove(employee);
        }
    }
}
