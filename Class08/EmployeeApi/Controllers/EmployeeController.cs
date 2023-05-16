using Microsoft.AspNetCore.Mvc;
using EmployeeApi.Models;

namespace EmployeeApi.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class EmployeeController : ControllerBase
{
    public static List<Employee> EmployeesDatabase = new List<Employee>();

    //get
    [HttpGet]
    public List<Employee> Get()
    {
        return EmployeesDatabase;
    }

    //add
    [HttpPost]
    public string Add(int id, string name, string lastName)
    {
        // Employee employee = new Employee();
        // employee.Id = 1;
        // employee.Name = "John";
        // employee.LastName = "Ahmad";

        Employee employee = new Employee
        {
            Id = id,
            Name = name,
            LastName = lastName,
        };


        // Read about exceptions ضروري
        EmployeesDatabase.Add(employee);
        // 200 mb
        return "Employee Added" + " " + employee.Name;
    }

    //update
    [HttpPut]
    public string Update(Employee employee)
    {
        return $"Employee Updated: {employee.Name} {employee.LastName} {employee.Id}";
    }

    //delete
    [HttpDelete]
    public string Delete(int id)
    {
        foreach (Employee employee in EmployeesDatabase)
        {
            if (employee.Id == id)
            {
                EmployeesDatabase.Remove(employee);
                break;
            }
        }

        return $"Employee Deleted {id}";
        // return "Employee Deleted" + " " + id;
    }
}
