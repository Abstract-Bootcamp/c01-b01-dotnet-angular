using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntroToOOP.Models
{
    public class Shape
    {
        public int Height { get; protected set; }
        public int Width { get; protected set; }

        public virtual int GetArea()
        {
            return Height * Height;
        }
    }

    public class Square : Shape
    {
        public Square(int height)
        {
            Height = height;
        }
    }

    public class Rectangle : Shape
    {
        public Rectangle(int height, int width)
        {
            Height = height;
            Width = width;
        }
        public override int GetArea()
        {
            return Width * Height;
        }
    }
}
