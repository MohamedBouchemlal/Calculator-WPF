namespace Calculator
{
    internal class CalculatorOperations
    {
        public string Add(string _operand1, string _operand2)
        {
            double a = double.Parse(_operand1);
            double b = double.Parse(_operand2);

            return (a + b).ToString();
        }

        public string Substract(string _operand1, string _operand2)
        {
            double a = double.Parse(_operand1);
            double b = double.Parse(_operand2);

            return (a - b).ToString();
        }

        public string Multiply(string _operand1, string _operand2)
        {
            double a = double.Parse(_operand1);
            double b = double.Parse(_operand2);

            return (a * b).ToString();
        }

        public string Divide(string _operand1, string _operand2)
        {
            double a = double.Parse(_operand1);
            double b = double.Parse(_operand2);
            return (a / b).ToString();
        }
    }
}
