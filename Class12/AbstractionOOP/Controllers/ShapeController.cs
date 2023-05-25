using Microsoft.AspNetCore.Mvc;
using AbstractionOOP.Models;

namespace AbstractionOOP.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class ShapeController : ControllerBase
{

    [HttpGet(Name = "GetShape")]
    public IEnumerable<int> Get()
    {
        List<IShape> shapes = new List<IShape>();
        IShape square = new Square()
        {
            Width = 10
        };
        IShape rectangle = new Rectangle()
        {
            Width = 10,
            Height = 20
        };

        shapes.Add(square);
        shapes.Add(rectangle);

        var result = new List<int>();
        foreach (IShape shape in shapes)
        {
            result.Add(shape.GetArea());
        }
        return result;
    }
}
