using GraphicEditor.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace GraphicEditor.Services
{
    public class DrawingManager
    {

        private readonly Canvas _canvas;
        private DrawingTool _currentTool;

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
            _currentTool = tool;
        }

        public void SetColor(Color color)
        {
            if (_currentTool != null)
            {
                _currentTool.CurrentColor = color;
            }
        }

        public void SetThickness(double thickness)
        {
            if (_currentTool != null)
            {
                _currentTool.CurrentThickness = thickness;
            }
        }

        public void ClearCanvas()
        {
            _canvas.Children.Clear();
        }
    }
}
