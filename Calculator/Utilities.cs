using System.Windows.Input;

namespace Calculator
{
    internal class Utilities
    {
        public string ConvertKeyIntoCalculatorInput(Key key)
        {
            string str = key.ToString();
            char c = '\0';

            if (str.Contains("NumPad"))
                c = str[str.Length - 1];

            else if (str.StartsWith('D') && str.Length == 2)
                c = str[str.Length - 1];

            else if (str == "Add")
                c = '+';
            else if (str == "Subtract")
                c = '-';
            else if (str == "Multiply")
                c = '*';
            else if (str == "Divide")
                c = '/';
            else if (str == "Decimal")
                c = ',';
            else if (str == "Return")
                c = '=';
            else if (str == "Back")
                return "Delete";

            return (c == '\0') ? "" : char.ToString(c);
        }

        public void DeleteLastCharInString(ref string str)
        {
            if (str.Length > 0)
            {
                int lastIndex = str.Length - 1;
                str = str.Remove(lastIndex);
            }
        }
    }
}
