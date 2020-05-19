using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace V8Features
{
    public enum Color
    {
        Unknown,
        Red,
        Blue,
        Green,
        Purple,
        Orange,
        Brown,
        Yellow
    }
    public class Circle : IShape
    {
        public int Radius { get; set; }

        public Circle(int radius) => Radius = radius;
    }

    public class Rectangle  : IShape
    {
        public int Length { get; }
        public int Width { get; }
        public Rectangle(int length, int width) =>
            (Length, Width) = (length, width);
    }

    public class Traingle : IShape
    {
        public int Side1 { get; set; }
        public int Side2 { get; set; }
        public int Side3 { get; set; }
        public Traingle(int side1, int side2, int side3) => (Side1, Side2, Side3) = (side1, side2, side3);
    }

    public static class SwitchExpressionSample
    {
        public static string GetInfoShape(IShape shape) => 
        shape switch
        {
            Circle r => $"Circle (r = {r.Radius})",
            Rectangle r => r switch
            {
                _ when r.Length == r.Width => $"Its Square",
                _ => ""
            },
            Traingle r => $"Traingle ({r.Side1},{r.Side2},{r.Side3})",
            _ => ""
        };
    }

    public static class SwitchExpressionTuple
    {
        public static Color GetColorTheme(Color color1, Color color2) => (color1,color2) switch
        {
            (Color.Blue , Color.Red) => Color.Orange,
            (Color.Green, Color.Brown) => Color.Red,

            (Color.Purple, Color.Orange) => Color.Yellow,
            (Color.Yellow, Color.Green) => Color.Blue,

            (_,_) => Color.Unknown

        };
    }
  }

