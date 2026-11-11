using GraphicEditor.Models;
using System.Windows;
using System.Windows.Controls;

namespace GraphicEditor.Tools
{
    public class RectangleTool : DrawingTool
    {
        public RectangleTool(Canvas canvas) : base(canvas) { }

        public override void OnMouseMove(Point position)
        {
            ClearPreview();
            var preview = new RectangleShape
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
            var finalShape = new RectangleShape
            {
                TopLeft = _startPoint,
                BottomRight = position,
                Color = CurrentColor,
                thickness = CurrentThickness
            };
            AddShape(finalShape.ToVisual());
        }
    }
}
