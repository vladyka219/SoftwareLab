using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SoftwareLab
{
    public class NotifyPropertyChanged : INotifyPropertyChanged
    {
        internal void SetValue<T>(ref T storage, in T value, [CallerMemberName] in string callName = "")
        {
            if (storage == null) throw new ArgumentNullException(nameof(storage));
            if (Equals(storage, value)) return;

            storage = value;
            OnPropertyChanged(callName);
        }

        #region PropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
