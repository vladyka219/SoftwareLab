using System.Text.RegularExpressions;

namespace SoftwareLab.Models
{
    public class SplitNumbersModel : NotifyPropertyChanged
    {
        public string Text
        {
            get => text;
            set
            {
                SetValue(ref text, Regex.Replace(value, @"[^0-9]+", ""));

                if (text.Length > 0)
                {
                    var number = uint.Parse(text[0].ToString());
                    sum = multiplication = number;

                    for (int i = 1; i < text.Length; i++)
                    {
                        number = uint.Parse(text[i].ToString());

                        multiplication *= number;
                        sum += number;
                    }
                }
                else
                {
                    multiplication = 0;
                    sum = 0;
                }

                OnPropertyChanged(nameof(Multiplication));
                OnPropertyChanged(nameof(Sum));
            }
        }

        public uint Multiplication
        {
            get => multiplication;
            set => SetValue(ref multiplication, value);
        }

        public uint Sum
        {
            get => sum;
            set => SetValue(ref sum, value);
        }

        #region PrivateVariables

        private string text = "";
        private uint multiplication = 0;
        private uint sum = 0;

        #endregion
    }
}
