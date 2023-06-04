using Microsoft.AspNetCore.Mvc;
using AdvancedApp.Models;
using AdvancedApp.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using AdvancedApp.ViewModels;

namespace AdvancedApp.Controllers;

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
    public async Task<IEnumerable<EmployeeVM>> Get()
    {
        var employees = await _context.Employees.Include(e => e.Job).ToListAsync();

        return employees.Select(e => new EmployeeVM
        {
            Name = e.Name,
            DateOfBirth = e.DateOfBirth.ToDateTime(new TimeOnly()),
            JobId = e.Job.Id
        });
    }

    [HttpGet("{id}")]
    public ActionResult<EmployeeVM> GetById(int id)
    {
        // try
        // {

        // add try catch
        var employee = _context.Employees.Include(e => e.Job).Single(e => e.Id == id);

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
        // }
        // catch (Exception ex)
        // {
        //     return BadRequest("Couldn't get employee! please contact the administrator");
        // }

    }

    [HttpPost]
    public async Task<ActionResult<int>> Create(EmployeeVM vm)
    {
        try
        {
            var newEmployee = new Employee
            {
                Name = vm.Name,
                DateOfBirth = DateOnly.FromDateTime(vm.DateOfBirth),
                Job = await _context.Jobs.FindAsync(vm.JobId)// check out why do we need to use Find instead of FirstOrDefault
            };

            _context.Employees.Add(newEmployee);
            await _context.SaveChangesAsync();
            return Ok(newEmployee.Id);
        }
        catch (Exception ex)
        {
            //log
            return BadRequest("Couldn't create employee! please contact the administrator");
        }
    }
}
