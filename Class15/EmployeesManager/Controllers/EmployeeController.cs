using Microsoft.AspNetCore.Mvc;
using EmployeesManager.Models;
using EmployeesManager.ViewModels;
using EmployeesManager.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EmployeesManager.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class EmployeeController : ControllerBase
{
    private readonly EmployeeContext _context;
    public EmployeeController(EmployeeContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IEnumerable<Employee> Get()
    {
        return _context.Employees.ToList();
    }

    [HttpGet("{id}")]
    public ActionResult<EmployeeVM> Get(int id)
    {
        var employee = _context.Employees.Include(e => e.Job).SingleOrDefault(e => e.Id == id);
        if (employee == null)
        {
            return NotFound();
        }
        return new EmployeeVM
        {
            Name = employee.Name,
            DateOfBirth = employee.DateOfBirth,
            Job = new JobVM
            {
                Position = employee.Job.Position
            }
        };
    }

    [HttpPost]
    public IActionResult Create(EmployeeVM employee)
    {
        var newEmployee = new Employee
        {
            Name = employee.Name,
            DateOfBirth = employee.DateOfBirth,
            Job = _context.Jobs.Find(employee.Job.Id)
        };
        _context.Employees.Add(newEmployee);
        _context.SaveChanges();
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var employee = _context.Employees.Find(id);
        if (employee == null)
        {
            return NotFound();
        }
        _context.Employees.Remove(employee);
        _context.SaveChanges();
        return Ok(id);
    }
}
