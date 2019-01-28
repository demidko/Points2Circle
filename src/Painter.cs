using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

class Painter
{
    private readonly Canvas Artcanvas;

    public void DrawPoint(in Point p)
    {
        Artcanvas.Children.Add(new Ellipse()
        {
            Margin = new Thickness(p.X - 2, p.Y - 2, 0, 0),
            Fill = Brushes.Red,
            Width = 7,
            Height = 7
        });
    }

    public void DrawCircle(in Ellipse circle)
    {
        circle.StrokeThickness = 2;
        circle.Stroke = Brushes.Blue;
        Artcanvas.Children.Add(circle);
    }

    public void Clear()
    {
        Artcanvas.Children.Clear();
    }

    public Painter(in Canvas c)
    {
        Artcanvas = c;
    }
}