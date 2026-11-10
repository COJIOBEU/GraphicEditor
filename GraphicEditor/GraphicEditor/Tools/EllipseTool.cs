using System.Windows;
using System.Windows.Controls;
using GraphicEditor.Models;

namespace GraphicEditor.Tools
{
    public class EllipseTool : DrawingTool
    {
        private Point _startPoint;

        public EllipseTool(Canvas canvas) : base(canvas) { }

        public override void OnMouseMove(Point position)
        {
            ClearPreview();
            var preview = new EllipseShape
            {
                TopLeft = _startPoint,
                BottomRight = position,
                Color = CurrentColor,
                thickness = CurrentThickness
            };
            PreviewElement = preview.ToVisual();
            Canvas.Children.Add(PreviewElement);
        }

        public override void OnMouseUp(Point position)
        {
            ClearPreview();
            var finalShape = new EllipseShape
            {
                TopLeft = _startPoint,
                BottomRight = position,
                Color = CurrentColor,
                thickness = CurrentThickness
            };
            Canvas.Children.Add(finalShape.ToVisual());
        }
    }
}
