using SoftwareLab.ViewModels;

namespace SoftwareLab.Items
{
    public partial class Item1
    {
        public Item1()
        {
            InitializeComponent();

            DataContext = new SquareNumberViewModel();
        }
    }
}
