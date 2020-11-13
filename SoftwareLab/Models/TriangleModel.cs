using System;

namespace SoftwareLab.Models
{
    public class TriangleModel : NotifyPropertyChanged
    {
        public double Square
        {
            get => square;
            set => SetValue(ref square, value);
        }

        public Point Point1 { get; } = new Point(50, 150);

        public Point Point2 { get; } = new Point(150, 50);

        public Point Point3 { get; } = new Point(250, 150);

        public TriangleModel()
        {
            Point1.PropertyChanged += (sender, args) => OnPropertyChanged(nameof(Point1));
            Point2.PropertyChanged += (sender, args) => OnPropertyChanged(nameof(Point2));
            Point3.PropertyChanged += (sender, args) => OnPropertyChanged(nameof(Point3));
        }

        #region PrivateVariables

        private double square;

        #endregion
    }

    public class Point : NotifyPropertyChanged
    {
        public double X
        {
            get => x;
            set => SetValue(ref x, value);
        }

        public double Y
        {
            get => y;
            set => SetValue(ref y, value);
        }

        public Point()
        {
            x = 0;
            y = 0;
        }

        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public System.Windows.Point ToWindowsPoint() => new System.Windows.Point(x, y);

        public override string ToString() => $"{x:#.#}; {y:#.#}";

        #region PrivateVariables

        private double x;
        private double y;

        #endregion
    }
}
