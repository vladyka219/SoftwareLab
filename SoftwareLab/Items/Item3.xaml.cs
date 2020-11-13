using System.Windows.Input;
using SoftwareLab.ViewModels;

namespace SoftwareLab.Items
{
    public partial class Item3
    {
        public Item3()
        {
            InitializeComponent();

            DataContext = chessViewModel;
        }

        private void Image_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e) => chessViewModel.ChangeFirstColor(Image, e);

        private void Image_OnMouseRightButtonDown(object sender, MouseButtonEventArgs e) => chessViewModel.ChangeSecondColor(Image, e);

        #region PrivateVariables

        private readonly ChessViewModel chessViewModel = new ChessViewModel();

        #endregion
    }
}
