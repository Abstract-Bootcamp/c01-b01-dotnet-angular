using Microsoft.AspNetCore.Mvc;
using EmployeesManager.Models;
using EmployeesManager.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using EmployeesManager.ViewModels;

namespace EmployeesManager.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class EmployeeController : ControllerBase
{
    private readonly EmployeeMgrContext _context;
    public EmployeeController(EmployeeMgrContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IEnumerable<EmployeeVM> Get()
    {
        var employees = _context.Employees.Include(e => e.Job).ToList();

        return employees.Select(e => new EmployeeVM
        {
            Name = e.Name,
            DateOfBirth = e.DateOfBirth.ToDateTime(new TimeOnly()),
            JobId = e.Job.Id
        });

        // var result = new List<EmployeeVM>();
        // var employees = _context.Employees.ToList();
        // foreach (var employee in employees)
        // {
        //     result.Add(new EmployeeVM
        //     {
        //         Name = employee.Name,
        //         DateOfBirth = employee.DateOfBirth
        //     });
        // }

        // return result;
    }

    [HttpGet("{id}")]
    public ActionResult<EmployeeVM> GetById(int id)
    {
        // add try catch
        var employee = _context.Employees.Include(e => e.Job).SingleOrDefault(e => e.Id == id);

        if (employee is null)
        {
            return NotFound();
        }
        else
        {
            return new EmployeeVM
            {
                Name = employee.Name,
                DateOfBirth = employee.DateOfBirth.ToDateTime(new TimeOnly()),
                JobId = employee.Job.Id
            };
        }
    }

    [HttpPost]
    public ActionResult<int> Create(EmployeeVM vm)
    {
        try
        {
            var newEmployee = new Employee
            {
                Name = vm.Name,
                DateOfBirth = DateOnly.FromDateTime(vm.DateOfBirth),
                Job = _context.Jobs.Find(vm.JobId)// check out why do we need to use Find instead of FirstOrDefault
            };

            _context.Employees.Add(newEmployee);
            _context.SaveChanges();
            return Ok(newEmployee.Id);
        }
        catch (Exception ex)
        {
            //log
            return BadRequest("Couldn't create employee! please contact the administrator");
        }

    }
}
