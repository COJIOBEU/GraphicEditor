using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace GraphicEditor.Tools
{
    public abstract class DrawingTool
    {
        public Color CurrentColor { get; set; } = Colors.Black;
        public double CurrentThickness { get; set; } = 2;

        protected Canvas Canvas { get; private set; }
        protected UIElement PreviewElement { get; set; }
        protected Point _startPoint;

        public DrawingTool(Canvas canvas)
        {
            Canvas = canvas;
        }

        public virtual void OnMouseDown(Point position)
        {
            _startPoint = position;
        }
        public abstract void OnMouseMove(Point position);
        public abstract void OnMouseUp(Point position);

        protected void ClearPreview()
        {
            if (PreviewElement != null)
            {
                Canvas.Children.Remove(PreviewElement);
                PreviewElement = null;
            }
        }
    }
}
