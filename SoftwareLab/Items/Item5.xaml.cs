using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using SoftwareLab.Models;
using SoftwareLab.ViewModels;

namespace SoftwareLab.Items
{
    public partial class Item5
    {
        public GraphModel GraphModel = new GraphModel();

        public Item5()
        {
            InitializeComponent();

            GraphModel.PropertyChanged += GraphModelOnPropertyChanged;

            DataContext = new
            {
                GraphModel
            };
        }

        private void Item5_OnUnloaded(object sender, RoutedEventArgs e) => GraphModel.PropertyChanged -= GraphModelOnPropertyChanged;

        private void ContentGrid_OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            actualWidth = e.NewSize.Width;
            actualHeight = e.NewSize.Height;

            UpdateGraph();
        }

        private void GraphModelOnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(GraphModel.Text):
                {
                    UpdateGraph();
                    break;
                }
            }
        }

        private void UpdateGraph()
        {
            Canvas.Children.Clear();

            if (string.IsNullOrEmpty(GraphModel.Text)) return;

            int lastNumber = int.Parse(GraphModel.Text[0].ToString());


            for (int i = 1; i < GraphModel.Text.Length; i++)
            {
                var number = int.Parse(GraphModel.Text[i].ToString());

                Canvas.Children.Add(new Line
                {
                    Stroke = GetColor(Math.Sign(number - lastNumber)),
                    StrokeThickness = 2,
                    X1 = ((actualWidth / 9.0) * (i - 1)),
                    Y1 = actualHeight - ((actualHeight / 9.0) * lastNumber),
                    X2 = ((actualWidth / 9.0) * i),
                    Y2 = actualHeight - ((actualHeight / 9.0) * number),
                });

                lastNumber = number;
            }
        }

        private SolidColorBrush GetColor(int i)
        {
            switch (i)
            {
                case -1:
                    return new SolidColorBrush(Colors.Red);
                case 1:
                    return new SolidColorBrush(Colors.Green);
                default:
                    return new SolidColorBrush(Colors.DimGray);
            }
        }


        #region PrivateVariables

        private static double margin = 10;
        private double actualWidth;
        private double actualHeight;

        #endregion
    }
}
