using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.Win32;
using GraphicEditor.Services;
using GraphicEditor.Tools;
using GraphicEditor.Repositories;

namespace GraphicEditor
{
    public partial class MainWindow : Window
    {
        private DrawingManager _manager;
        private IImageRepository _repository;

        public MainWindow()
        {
            InitializeComponent();

            KeyDown += MainWindow_KeyDown;

            _manager = new DrawingManager(DrawingCanvas);
            _repository = new PngImageRepository(DrawingCanvas);
        }

        private void PencilButton_Click(object sender, RoutedEventArgs e) =>
            _manager.SetTool(new PencilTool(DrawingCanvas));

        private void LineButton_Click(object sender, RoutedEventArgs e) =>
            _manager.SetTool(new LineTool(DrawingCanvas));

        private void RectButton_Click(object sender, RoutedEventArgs e) =>
            _manager.SetTool(new RectangleTool(DrawingCanvas));

        private void EllipseButton_Click(object sender, RoutedEventArgs e) =>
            _manager.SetTool(new EllipseTool(DrawingCanvas));

        private void ColorComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_manager == null) return;

            if (ColorComboBox.SelectedItem is ComboBoxItem item)
            {
                var color = (Color)ColorConverter.ConvertFromString(item.Content.ToString());
                _manager.SetColor(color);
            }
        }

        private void ThicknessComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_manager == null) return;

            if (ThicknessComboBox.SelectedItem is ComboBoxItem item)
            {
                if (double.TryParse(item.Content.ToString(), out double thickness))
                {
                    _manager.SetThickness(thickness);
                }
            }
        }

        private void UndoButton_Click(object sender, RoutedEventArgs e)
        {
            _manager.Undo();
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            _manager.ClearCanvas();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new SaveFileDialog
            {
                Filter = "PNG Image|*.png",
                DefaultExt = ".png"
            };

            if (dialog.ShowDialog() == true)
            {
                try
                {
                    _repository.Save(dialog.FileName);
                    MessageBox.Show("Изображение успешно сохранено!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при сохранении: " + ex.Message);
                }
            }
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Z &&
                (Keyboard.Modifiers & ModifierKeys.Control) != 0)
            {
                _manager.Undo();
                e.Handled = true;
            }
        }
    }
}