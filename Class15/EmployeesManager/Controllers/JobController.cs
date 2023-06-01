using Microsoft.AspNetCore.Mvc;
using EmployeesManager.Models;
using EmployeesManager.ViewModels;
using EmployeesManager.DataAccess;

namespace EmployeesManager.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class JobController : ControllerBase
{
    private readonly EmployeeContext _context;
    public JobController(EmployeeContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IEnumerable<Job> Get()
    {
        return _context.Jobs.ToList();
    }

    [HttpGet("{id}")]
    public ActionResult<JobVM> Get(int id)
    {
        var job = _context.Jobs.Find(id);
        if (job == null)
        {
            return NotFound();
        }
        return new JobVM
        {
            Position = job.Position
        };
    }

    [HttpPost]
    public IActionResult Create(JobVM job)
    {
        var newJob = new Job
        {
            Position = job.Position
        };
        _context.Jobs.Add(newJob);
        _context.SaveChanges();
        return Ok();
    }
}
