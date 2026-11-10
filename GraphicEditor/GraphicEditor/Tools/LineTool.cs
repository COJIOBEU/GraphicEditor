using GraphicEditor.Models;
using System.Windows;
using System.Windows.Controls;

namespace GraphicEditor.Tools
{
    public class LineTool : DrawingTool
    {
        private Point _startPoint;

        public LineTool(Canvas canvas) : base(canvas) { }

        public override void OnMouseMove(Point position)
        {
            ClearPreview();
            var preview = new LineShape
            {
                start = _startPoint,
                end = position,
                Color = CurrentColor,
                thickness = CurrentThickness
            };
            PreviewElement = preview.ToVisual();
            Canvas.Children.Add(PreviewElement);
        }

        public override void OnMouseUp(Point position)
        {
            ClearPreview();
            var finalShape = new LineShape
            {
                start = _startPoint,
                end = position,
                Color = CurrentColor,
                thickness = CurrentThickness
            };
            Canvas.Children.Add(finalShape.ToVisual());
        }
    }
}
