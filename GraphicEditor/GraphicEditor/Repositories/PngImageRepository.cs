using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace GraphicEditor.Repositories
{
    public class PngImageRepository : IImageRepository
    {
        private readonly Canvas _canvas;

        public PngImageRepository(Canvas canvas)
        {
            _canvas = canvas;
        }

        public void Save(string filePath)
        {
            var renderBitmap = new RenderTargetBitmap(
                (int)_canvas.ActualWidth,
                (int)_canvas.ActualHeight,
                96, 96,
                PixelFormats.Pbgra32);

            renderBitmap.Render(_canvas);

            var pngEncoder = new PngBitmapEncoder();
            pngEncoder.Frames.Add(BitmapFrame.Create(renderBitmap));

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                pngEncoder.Save(fileStream);
            }
        }
    }
}
