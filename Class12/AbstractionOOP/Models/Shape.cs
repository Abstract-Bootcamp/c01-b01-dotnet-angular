using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbstractionOOP.Models
{

    public interface IShape
    {
        int Width { get; set; }
        int GetArea();
    }

    public interface IRectangle : IShape
    {
        int Height { get; set; }
    }

    public abstract class Shape : IShape
    {
        public int Width { get; set; }
        public int GetArea()
        {
            return Width * Width;
        }

        public abstract int GetWidth();
    }

    public class Square : Shape
    {
        public override int GetWidth()
        {
            return Width;
        }
    }

    public class Rectangle : IRectangle
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public int GetArea()
        {
            return Width * Height;
        }
    }
}
