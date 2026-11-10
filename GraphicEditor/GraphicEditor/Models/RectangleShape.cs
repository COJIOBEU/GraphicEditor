using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace GraphicEditor.Models
{
    public class RectangleShape : Shape
    {
        public Point TopLeft { get; set; }
        public Point BottomRight { get; set; }

        public override UIElement ToVisual()
        {
            var x = Math.Min(TopLeft.X, BottomRight.X);
            var y = Math.Min(TopLeft.Y, BottomRight.Y);
            var width = Math.Abs(BottomRight.X - TopLeft.X);
            var height = Math.Abs(BottomRight.Y - TopLeft.Y);

            var rect = new System.Windows.Shapes.Rectangle
            {
                Width = width,
                Height = height,
                Stroke = new SolidColorBrush(Color),
                StrokeThickness = thickness
            };
            Canvas.SetLeft(rect, x);
            Canvas.SetTop(rect, y);
            return rect;
        }
    }
}
