using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using GraphicEditor.Tools;

namespace GraphicEditor.Services
{
    public class DrawingManager
    {
        private readonly Canvas _canvas;
        private DrawingTool _currentTool;
        private Color _currentColor = Colors.Black;
        private double _currentThickness = 3;

        private readonly Stack<UIElement> _history = new Stack<UIElement>();

        public DrawingManager(Canvas canvas)
        {
            _canvas = canvas;

            _canvas.MouseLeftButtonDown += Canvas_MouseLeftButtonDown;
            _canvas.MouseMove += Canvas_MouseMove;
            _canvas.MouseLeftButtonUp += Canvas_MouseLeftButtonUp;

            SetTool(new PencilTool(_canvas));
        }

        private void Canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _canvas.CaptureMouse();
            Point position = e.GetPosition(_canvas);
            _currentTool.OnMouseDown(position);
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (_canvas.IsMouseCaptured)
            {
                Point position = e.GetPosition(_canvas);
                _currentTool.OnMouseMove(position);
            }
        }

        private void Canvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            _canvas.ReleaseMouseCapture();
            Point position = e.GetPosition(_canvas);
            _currentTool.OnMouseUp(position);
        }

        public void SetTool(DrawingTool tool)
        {
            tool.Manager = this;
            tool.CurrentColor = _currentColor;
            tool.CurrentThickness = _currentThickness;
            _currentTool = tool;
        }

        public void SetColor(Color color)
        {
            _currentColor = color;
            if (_currentTool != null)
            {
                _currentTool.CurrentColor = color;
            }
        }

        public void SetThickness(double thickness)
        {
            _currentThickness = thickness;
            if (_currentTool != null)
            {
                _currentTool.CurrentThickness = thickness;
            }
        }

        public void ClearCanvas()
        {
            _canvas.Children.Clear();
            _history.Clear();
        }

        public bool Undo()
        {
            if (_history.Count == 0)
                return false;

            var lastShape = _history.Pop();
            _canvas.Children.Remove(lastShape);
            return true;
        }

        public void RegisterShape(UIElement shape)
        {
            if (shape != null)
                _history.Push(shape);
        }
    }
}