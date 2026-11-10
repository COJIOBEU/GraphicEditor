using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace GraphicEditor.Models
{
    public class PolylineShape : Shape
    {
        public List<Point> Points { get; } = new List<Point>();
        public override UIElement ToVisual()
        {
            var polyline = new Polyline
            {
                Stroke = new SolidColorBrush(Color),
                StrokeThickness = thickness
            };
            foreach (var point in Points)
            {
                polyline.Points.Add(point);
            }
            return polyline;
        }
    }
}
