using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using GraphicEditor.Services;

namespace GraphicEditor.Tools
{
    public abstract class DrawingTool
    {
        public Color CurrentColor { get; set; } = Colors.Black;
        public double CurrentThickness { get; set; } = 2;

        protected Canvas Canvas { get; private set; }
        protected UIElement PreviewElement { get; set; }
        protected Point _startPoint;
        public DrawingManager Manager { get; set; }

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

        protected void AddShape(UIElement shape)
        {
            Canvas.Children.Add(shape);
            Manager?.RegisterShape(shape);
        }
    }
}