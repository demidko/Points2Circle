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

// Collector of 3 points
class PointCollector
{
    private readonly PointCollection Col = new PointCollection();

    public PointCollection Push(in Point p)
    {
        if(Col.Count == 2)
        {
            var res = new PointCollection(Col);
            res.Add(p);
            Col.Clear();
            return res;
        }
        Col.Add(p);
        return null;
    }
}


