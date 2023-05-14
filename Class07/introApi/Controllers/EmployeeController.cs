using introApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace introApi.Controllers;


[ApiController]
[Route("[controller]/[action]")]
public class EmployeeController : ControllerBase
{
    [HttpGet(Name = "GetAllEmployees")]
    public List<Employee> GetEmployees()
    {
        var employees = new List<Employee>();
        employees.Add(new Employee { Id = 1, Name = "John" });
        employees.Add(new Employee { Id = 2, Name = "Husni" });

        return employees;
    }

    // get employee by id - Get

    // update employee 
    // [HttpPut]

    [HttpPost(Name = "AddEmployee")]
    public string AddEmployee()
    {
        return "Employee added";
    }
}
