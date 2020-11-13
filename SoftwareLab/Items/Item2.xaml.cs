using SoftwareLab.Models;

namespace SoftwareLab.Items
{
    public partial class Item2
    {
        public Item2()
        {
            InitializeComponent();

            DataContext = new SplitNumbersModel();
        }
    }
}
