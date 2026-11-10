using System.Windows;
using System.Windows.Media;

namespace GraphicEditor.Models
{
    public abstract class Shape
    {
        public Color Color { get; set; } = Colors.Black;
        public double thickness { get; set; } = 2;

        public abstract UIElement ToVisual();
    }
}
