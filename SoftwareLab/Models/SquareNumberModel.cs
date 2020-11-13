namespace SoftwareLab.Models
{
    public class SquareNumberModel : NotifyPropertyChanged
    {
        public uint Number
        {
            get => number;
            set
            {
                SetValue(ref number, value);
                SquareNumber = number * number;
            }
        }

        public ulong SquareNumber
        {
            get => squareNumber;
            private set => SetValue(ref squareNumber, value);
        }

        #region PrivateVariables

        private uint number;
        private ulong squareNumber;

        #endregion
    }
}
