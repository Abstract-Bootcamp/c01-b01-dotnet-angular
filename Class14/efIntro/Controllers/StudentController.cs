using Microsoft.AspNetCore.Mvc;
using efIntro.Models;
using efIntro.DataAccess;

namespace efIntro.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class StudentController : ControllerBase
{
    private readonly AppDbContext _context;

    public StudentController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IEnumerable<Student> Create(Student student)
    {
        _context.Students.Add(student);
        _context.SaveChanges();
        return _context.Students.ToList();
    }
}
