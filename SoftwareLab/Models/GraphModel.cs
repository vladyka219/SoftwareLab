using System.Text.RegularExpressions;

namespace SoftwareLab.Models
{
    public class GraphModel : NotifyPropertyChanged
    {
        public string Text
        {
            get => text;
            set => SetValue(ref text, Regex.Replace(value, @"[^0-9]+", ""));
        }

        #region PrivateVariables

        private string text = "";

        #endregion
    }
}
