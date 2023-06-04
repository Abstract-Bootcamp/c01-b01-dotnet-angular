using Microsoft.AspNetCore.Mvc;
using AdvancedApp.Models;
using AdvancedApp.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using AdvancedApp.ViewModels;

namespace AdvancedApp.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class JobController : ControllerBase
{
    private readonly EmployeeMgrContext _context;
    public JobController(EmployeeMgrContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<JobVM>> Get()
    {
        var jobs = _context.Jobs.ToList();
        return jobs.Select(j => new JobVM
        {
            Position = j.Position,
            Description = j.Description,
        }).ToList();
    }

    [HttpPost]
    public ActionResult<int> Create(JobVM vm)
    {
        var newJob = new Job
        {
            Position = vm.Position,
            Description = vm.Description
        };

        _context.Jobs.Add(newJob);

        _context.SaveChanges();
        return Ok(newJob.Id);
    }
}
