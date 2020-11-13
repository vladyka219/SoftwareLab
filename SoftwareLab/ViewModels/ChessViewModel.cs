using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using SoftwareLab.Models;
using Point = System.Windows.Point;

namespace SoftwareLab.ViewModels
{
    public class ChessViewModel : NotifyPropertyChanged
    {
        public SolidColorBrush Result
        {
            get => result;
            set => SetValue(ref result, value);
        }

        public SolidColorBrush FirstBrush
        {
            get => firstBrush;
            set => SetValue(ref firstBrush, value);
        }

        public SolidColorBrush SecondBrush
        {
            get => secondBrush;
            set => SetValue(ref secondBrush, value);
        }

        public ChessModel ChessModel => chessModel;

        public void ChangeFirstColor(Image image, MouseButtonEventArgs e)
        {
            SelectColor(image, e, out firstBrush);
            OnPropertyChanged(nameof(FirstBrush));
        }

        public void ChangeSecondColor(Image image, MouseButtonEventArgs e)
        {
            SelectColor(image, e, out secondBrush);
            OnPropertyChanged(nameof(SecondBrush));
        }

        private void SelectColor(Image image, MouseButtonEventArgs e, out SolidColorBrush brush)
        {
            Point point = e.GetPosition(image);

            var sizeWidth = image.ActualWidth / chessModel.SizeX;
            var sizeHeight = image.ActualHeight / chessModel.SizeY;

            var x = (int)(point.X / sizeWidth);
            var y = (int)(point.Y / sizeHeight);

            var color = chessModel.Colors[chessModel.Chess[x, y]];
            brush = new SolidColorBrush(Color.FromRgb(color.R, color.G, color.B));

            CompaireColors();
        }

        private void CompaireColors() => Result = Brushes[Convert.ToInt32(Equals(firstBrush.Color, secondBrush.Color))];

        #region PrivateVariables

        private readonly ChessModel chessModel = new ChessModel();
        private SolidColorBrush result = new SolidColorBrush();
        private SolidColorBrush firstBrush = new SolidColorBrush();
        private SolidColorBrush secondBrush = new SolidColorBrush();
        private SolidColorBrush[] Brushes = new[]
        {
            new SolidColorBrush(Colors.Red),
            new SolidColorBrush(Colors.Lime)
        };

        #endregion
    }
}
