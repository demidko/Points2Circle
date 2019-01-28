using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


partial class MainWindow : Window
{
    readonly PointCollector MyCollector = new PointCollector();
    readonly Painter MyPainter;
    bool WasCircle = false;

    void ArtcanvasMouseDown(object sender, MouseButtonEventArgs e)
    {
        if(WasCircle)
        {
            Title = "Points2Circle";
            MyPainter.Clear();
            WasCircle = false;
        }
        var p = e.GetPosition(Artcanvas);
        MyPainter.DrawPoint(p);
        if (MyCollector.Push(p) is PointCollection col && col != null)
        {
            WasCircle = true;
            MyPainter.DrawCircle(Points2Circle.Calculator.CalculateCircle(col[0], col[1], col[2]));

            Title = "";
            foreach(var i in col)
            {
                Title += $"({i}) ";
            }

            return;
        }
    }

    MainWindow()
    {
        InitializeComponent();
        MyPainter = new Painter(Artcanvas);
    }

    [STAThread] static void Main() => new Application().Run(new MainWindow());
}