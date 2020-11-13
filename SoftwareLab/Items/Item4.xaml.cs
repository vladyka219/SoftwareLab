using System;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using SoftwareLab.Models;

namespace SoftwareLab.Items
{
    public partial class Item4
    {
        public Item4()
        {
            InitializeComponent();

            DataContext = triangleModel;

            triangleModel.PropertyChanged += (sender, args) =>
            {
                switch (args.PropertyName)
                {
                    case nameof(triangleModel.Point1):
                    case nameof(triangleModel.Point2):
                    case nameof(triangleModel.Point3):
                        UpdateTriangle();
                        break;
                }
            };

            UpdateTriangle();
        }

        private void UpdateTriangle()
        {
            Polygon.Points = new PointCollection()
            {
                triangleModel.Point1.ToWindowsPoint(),
                triangleModel.Point2.ToWindowsPoint(),
                triangleModel.Point3.ToWindowsPoint()
            };

            UpdateSquare();
        }
        private void UpdateSquare()
        {
            double a = Math.Abs(Math.Sqrt(Math.Pow(triangleModel.Point2.X - triangleModel.Point1.X, 2.0) + Math.Pow(triangleModel.Point2.Y - triangleModel.Point1.Y, 2.0))); // сторона a
            double b = Math.Abs(Math.Sqrt(Math.Pow(triangleModel.Point3.X - triangleModel.Point2.X, 2.0) + Math.Pow(triangleModel.Point3.Y - triangleModel.Point2.Y, 2.0))); // сторона b
            double c = Math.Abs(Math.Sqrt(Math.Pow(triangleModel.Point1.X - triangleModel.Point3.X, 2.0) + Math.Pow(triangleModel.Point1.Y - triangleModel.Point3.Y, 2.0))); // сторона c

            double p = (a + b + c) / 2.0; // полупериметр

            triangleModel.Square = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }

        private void Thumb1_OnDragDelta(object sender, DragDeltaEventArgs e)
        {
            triangleModel.Point1.X += e.HorizontalChange;
            triangleModel.Point1.Y += e.VerticalChange;
        }

        private void Thumb2_OnDragDelta(object sender, DragDeltaEventArgs e)
        {
            triangleModel.Point2.X += e.HorizontalChange;
            triangleModel.Point2.Y += e.VerticalChange;
        }

        private void Thumb3_OnDragDelta(object sender, DragDeltaEventArgs e)
        {
            triangleModel.Point3.X += e.HorizontalChange;
            triangleModel.Point3.Y += e.VerticalChange;
        }

        #region PrivateVariables

        private readonly TriangleModel triangleModel = new TriangleModel();

        #endregion
    }
}