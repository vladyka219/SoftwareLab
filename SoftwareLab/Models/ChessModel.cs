using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Media.Imaging;
using Brush = System.Drawing.Brush;

namespace SoftwareLab.Models
{
    public class ChessModel : NotifyPropertyChanged
    {
        public readonly byte SizeX = 8;

        public readonly byte SizeY = 8;

        public byte[,] Chess { get; } =
        {
            {0x0, 0x1, 0x0, 0x1, 0x0, 0x1, 0x0, 0x1},
            {0x1, 0x0, 0x1, 0x0, 0x1, 0x0, 0x1, 0x0},
            {0x0, 0x1, 0x0, 0x1, 0x0, 0x1, 0x0, 0x1},
            {0x1, 0x0, 0x1, 0x0, 0x1, 0x0, 0x1, 0x0},
            {0x0, 0x1, 0x0, 0x1, 0x0, 0x1, 0x0, 0x1},
            {0x1, 0x0, 0x1, 0x0, 0x1, 0x0, 0x1, 0x0},
            {0x0, 0x1, 0x0, 0x1, 0x0, 0x1, 0x0, 0x1},
            {0x1, 0x0, 0x1, 0x0, 0x1, 0x0, 0x1, 0x0}
        };

        public System.Drawing.Color[] Colors =
        {
            System.Drawing.Color.Bisque,
            System.Drawing.Color.Black
        };

        public BitmapImage ChessImage { get; private set; }

        public ChessModel()
        {
            GenerateChess();
        }

        private void GenerateChess()
        {
            int widht = 100;
            int height = 100;

            using (var bitmap = new Bitmap(800, 800))
            using (var graphics = Graphics.FromImage(bitmap))
            {
                for (int y = 0; y < SizeY; y++)
                    for (int x = 0; x < SizeX; x++)
                        using (Brush brush = new SolidBrush(Colors[Chess[x, y]]))
                            graphics.FillRectangle(brush, widht * x, height * y, widht, height);


                using (MemoryStream memoryStream = new MemoryStream())
                {
                    bitmap.Save(memoryStream, ImageFormat.Jpeg);

                    memoryStream.Position = 0;

                    ChessImage = new BitmapImage();
                    ChessImage.BeginInit();
                    ChessImage.StreamSource = memoryStream;
                    ChessImage.CacheOption = BitmapCacheOption.OnLoad;
                    ChessImage.EndInit();

                    OnPropertyChanged(nameof(ChessImage));
                }
            }
        }
    }
}
