using System;
using System.Windows;
using System.Windows.Shapes;

namespace Points2Circle
{
    static class Calculator
    {
        public static Ellipse CalculateCircle(in Point a, in Point b, in Point c)
        {
            var ma = (b.Y - a.Y) / (b.X - a.X);
            var mb = (c.Y - b.Y) / (c.X - b.X);
            var center_x =
                (ma * mb * (a.Y - c.Y) + mb * (a.X + b.X) - ma * (b.X + c.X))
                /
                (2 * (mb - ma));
            var center_y =
                (-(1 / ma)) * (center_x - ((a.X + b.X) / 2)) + ((a.Y + b.Y) / 2);
            var radius = Math.Sqrt(Math.Pow(center_x - a.X, 2) + Math.Pow(center_y - a.Y, 2));
            return new Ellipse()
            {
                Margin = new Thickness(center_x - radius, center_y - radius, 0, 0),
                Height = radius * 2,
                Width = radius * 2
            };
        }
    }
}
