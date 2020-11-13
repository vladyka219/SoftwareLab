using System.Collections.Generic;
using System.Collections.ObjectModel;
using SoftwareLab.Models;

namespace SoftwareLab.ViewModels
{
    public sealed class SquareNumberViewModel : NotifyPropertyChanged
    {
        public IEnumerable<SquareNumberModel> SquareNumberModels => squareNumberModels;

        public byte Values
        {
            get => values;
            set
            {
                SetValue(ref values, value);
                UpdateCollection();
            }
        }

        public SquareNumberViewModel()
        {
            UpdateCollection();
        }

        private void UpdateCollection()
        {
            squareNumberModels.Clear();

            for (uint i = 0; i <= values; i++)
            {
                squareNumberModels.Add(new SquareNumberModel()
                {
                    Number = i
                });
            }

            OnPropertyChanged(nameof(SquareNumberModels));
        }

        #region PrivateVariables

        private readonly ObservableCollection<SquareNumberModel> squareNumberModels = new ObservableCollection<SquareNumberModel>();
        private byte values = 10;

        #endregion
    }
}
