using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Calculator
{
    public partial class MainWindow : Window
    {
        string _operand1 = "", _operator = "", _operand2 = "";
        string _result = "";
        bool _operationExecuted = false;

        readonly Utilities utilities = new Utilities();
        readonly CalculatorOperations calculatorOperations = new CalculatorOperations();

        public MainWindow()
        {
            InitializeComponent(); ;
            InitializeAllButtons();
        }

        private void InitializeAllButtons()
        {
            foreach (UIElement UI in UIElements.Children)
            {
                if (UI is Button)
                {
                    ((Button)UI).Click += AllButtons_Click;
                }
            }
        }

        //If the user uses keyboard
        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            string convertedKey = utilities.ConvertKeyIntoCalculatorInput(e.Key);
            CalculatorFunction(convertedKey);
        }
        //If the user uses/clicks on buttons
        private void AllButtons_Click(object sender, RoutedEventArgs e)
        {
            string btnContent = e != null ? ((Button)e.OriginalSource).Content.ToString() : "";
            CalculatorFunction(btnContent);
        }

        private void CalculatorFunction(string str)
        {
            switch (str)
            {
                case "Delete":

                    BtnDelete();
                    break;

                case "Clear":
                    BtnClear();
                    break;

                case "x^2":
                    BtnPower2();
                    break;

                case "sqrt(x)":
                    BtnSqrt();
                    break;

                case "=":
                    StartOperation();           
                    break;

                case "+":case "-":case "*":case "/":
                    SetOperator(str);
                    break;

                case ",":
                    BtnDecimal(str);
                    break;

                default:
                    BtnNumbers(str);
                    break;
            }
            UpdateTextBlock();
        }

        private void BtnDelete()
        {
            if (_operand2 != "")
                utilities.DeleteLastCharInString(ref _operand2);

            else if (_operator != "")
                _operator = "";

            else
                utilities.DeleteLastCharInString(ref _operand1);
        }

        private void BtnClear()
        {
            ResetEquationElements();
            _result = "";
        }

        private void SetOperator(string str)
        {
            if (_operand1 != "" && _operand2 == "")
                _operator = str;
        }

        private void BtnDecimal(string str)
        {
            if (_operator == "")
            {
                if (!_operand1.Contains(str))
                    _operand1 += str;
            }
            else
            {
                if (!_operand2.Contains(str))
                    _operand2 += str;
            }
        }

        private void BtnNumbers(string str)
        {
            if (_operator == "")
                _operand1 += str;
            else
                _operand2 += str;
        }

        private void BtnSqrt(){

            if (_operand1 != "")
            {
                double a = double.Parse(_operand1);
                _result = Math.Sqrt(a).ToString();
                FinishOperation();
            }
        }
        private void BtnPower2()
        {
            if (_operand1 != "")
            {
                double a = double.Parse(_operand1);
                _result = Math.Pow(a, 2).ToString();
                FinishOperation();
            }
        }

        private void StartOperation()
        {
            if (_operand2 != "")
            {
                switch (_operator)
                {
                    case "+":
                        _result = calculatorOperations.Add(_operand1, _operand2);
                        _operationExecuted = true;
                        break;
                    case "-":
                        _result = calculatorOperations.Substract(_operand1, _operand2);
                        _operationExecuted = true;
                        break;
                    case "*":
                        _result = calculatorOperations.Multiply(_operand1, _operand2);
                        _operationExecuted = true;
                        break;
                    case "/":
                        _result = calculatorOperations.Divide(_operand1, _operand2);
                        _operationExecuted = true;
                        break;
                }
            }

            if (_operationExecuted)
                FinishOperation();
        }

        private void FinishOperation()
        {
            ResetEquationElements();
            _operand1 = _result;
            _operationExecuted = false;
        }

        private void ResetEquationElements()
        {
            _operand1 = ""; _operator = ""; _operand2 = "";
        }

        private void UpdateTextBlock()
        {
            textBlock.Text = _operand1 + _operator + _operand2;
        }    
    }
}