using System.Windows;
using System.Windows.Media;

namespace GraphicEditor.Models
{
    public class LineShape : Shape
    {
        public Point start { get; set; }
        public Point end { get; set; }

        public override UIElement ToVisual()
        {
            return new System.Windows.Shapes.Line
            {
                X1 = start.X,
                Y1 = start.Y,
                X2 = end.X,
                Y2 = end.Y,
                Stroke = new SolidColorBrush(Color),
                StrokeThickness = thickness
            };
        }
    }
}
