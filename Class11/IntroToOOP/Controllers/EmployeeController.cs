using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using IntroToOOP.Models;

namespace IntroToOOP.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class EmployeeController : ControllerBase
{
    private static readonly List<Employee> Employees = new List<Employee>();


    [HttpGet()]
    public List<int> GetEmployees(int id)
    {
        Sales e = new Sales();
        e.Id = id;
        e.Name = "Sales employee";
        e.GetName();
        e.Commission = 100;

        Employees.Add(e);

        Employee d = new Developer();
        d.Id = id;
        d.Name = "Dev employee";
        Employees.Add(d);

        Accountant accountant = new Accountant();
        accountant.GetName("1", 1);
        Employees.Add(accountant);



        List<Shape> shapes = new List<Shape>();

        Square square = new Square(5);
        // square.GetArea();
        shapes.Add(square);

        Rectangle rectangle = new Rectangle(2, 6);
        // rectangle.GetArea();
        shapes.Add(rectangle);
        List<int> shapeResults = new List<int>();

        foreach (Shape shape in shapes)
        {
            shapeResults.Add(shape.GetArea());
        }

        return shapeResults;

        // return Employees;
    }
}
