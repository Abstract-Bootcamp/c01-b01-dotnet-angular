using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IntroToEf.DataAccess;
using IntroToEf.Models;


namespace IntroToEf.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class EmployeeController : ControllerBase
{
    private readonly EfDbContext _context;
    public EmployeeController(EfDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public List<Employee> GetEmployees()
    {
        return _context.Employees.ToList();
    }
}
