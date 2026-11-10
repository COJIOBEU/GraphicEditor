using GraphicEditor.Models;
using System.Windows;
using System.Windows.Controls;

namespace GraphicEditor.Tools
{
    public class PencilTool : DrawingTool
    {
        private PolylineShape _currentShape;

        public PencilTool(Canvas canvas) : base(canvas) { }

        public override void OnMouseDown(Point position)
        {
            _currentShape = new PolylineShape
            {
                Color = CurrentColor,
                thickness = CurrentThickness
            };
            _currentShape.Points.Add(position);
        }

        public override void OnMouseMove(Point position)
        {
            if (_currentShape != null)
            {
                _currentShape.Points.Add(position);
                ClearPreview();
                PreviewElement = _currentShape.ToVisual();
                Canvas.Children.Add(PreviewElement);
            }
        }

        public override void OnMouseUp(Point position)
        {
            if (_currentShape != null && _currentShape.Points.Count > 1)
            {
                ClearPreview();
                var finalShape = _currentShape.ToVisual();
                Canvas.Children.Add(finalShape);
            }
            _currentShape = null;
        }
    }
}
