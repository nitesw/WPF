using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lesson_01_Calc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double lastNum, res;
        SelectOperator selectOperator;

        public MainWindow()
        {
            InitializeComponent();
            result.Content = "0";
        }

        private void NumberBtn(object sender, RoutedEventArgs e)
        {
            int selectedValue = 0;

            if(sender == oneBtn)
            {
                selectedValue = 1;
            }
            if (sender == twoBtn)
            {
                selectedValue = 2;
            }
            if (sender == threeBtn)
            {
                selectedValue = 3;
            }
            if (sender == fourBtn)
            {
                selectedValue = 4;
            }
            if (sender == fiveBtn)
            {
                selectedValue = 5;
            }
            if (sender == sixBtn)
            {
                selectedValue = 6;
            }
            if (sender == sevenBtn)
            {
                selectedValue = 7;
            }
            if (sender == eightBtn)
            {
                selectedValue = 8;
            }
            if (sender == nineBtn)
            {
                selectedValue = 9;
            }
            if (sender == zeroBtn)
            {
                selectedValue = 0;
            }

            if(result.Content.ToString() == "0")
            {
                result.Content = $"{selectedValue}";
            }
            else
            {
                result.Content = $"{result.Content}{selectedValue}";
            }
        }

        private void acBtn_Click(object sender, RoutedEventArgs e)
        {
            result.Content = "0";
            res = 0;
            lastNum = 0;
        }

        private void negativeBtn_Click(object sender, RoutedEventArgs e)
        {
            if(double.TryParse(result.Content.ToString(), out lastNum))
            {
                if(result.Content.ToString() != "0")
                {
                    lastNum = lastNum * -1;
                    result.Content = lastNum.ToString();
                }
            }
        }

        private void percentBtn_Click(object sender, RoutedEventArgs e)
        {
            double tmpNumber;

            if(double.TryParse(result.Content.ToString(), out tmpNumber))
            {
                tmpNumber = (tmpNumber / 100);
                if(tmpNumber != 0)
                {
                    tmpNumber += lastNum;
                }
                result.Content = tmpNumber.ToString();
            }
        }

        private void OperatorBtn_Click(object sender, RoutedEventArgs e)
        {
            if(double.TryParse(result.Content.ToString(), out lastNum))
            {
                result.Content = "0";
            }

            if(sender == divideBtn)
            {
                selectOperator = SelectOperator.Divide;
            }
            if (sender == multBtn)
            {
                selectOperator = SelectOperator.Multiply;
            }
            if (sender == plusBtn)
            {
                selectOperator = SelectOperator.Plus;
            }
            if (sender == minusBtn)
            {
                selectOperator = SelectOperator.Minus;
            }
        }

        private void equalBtn_Click(object sender, RoutedEventArgs e)
        {
            double newNum;
            if(double.TryParse(result.Content.ToString(), out newNum))
            {
                switch (selectOperator)
                {
                    case SelectOperator.Plus:
                        res = Calculate.Add(lastNum, newNum);
                        break;
                    case SelectOperator.Minus:
                        res = Calculate.Substitution(lastNum, newNum);
                        break;
                    case SelectOperator.Multiply:
                        res = Calculate.Multiply(lastNum, newNum);
                        break;
                    case SelectOperator.Divide:
                        res = Calculate.Division(lastNum, newNum);
                        break;
                }
                result.Content = res.ToString();
            }
        }

        private void pointBtn_Click(object sender, RoutedEventArgs e)
        {
            if(result.Content.ToString().Contains(","))
            {

            }
            else
            {
                result.Content = $"{result.Content},";
            }
        }

        public enum SelectOperator
        {
            Plus,
            Minus,
            Multiply,
            Divide
        }

        public class Calculate
        {
            public static double Add(double a, double b)
            {
                return a + b;
            }
            public static double Substitution(double a, double b)
            {
                return a - b;
            }
            public static double Multiply(double a, double b)
            {
                return a * b;
            }
            public static double Division(double a, double b)
            {
                if(b == 0)
                {
                    MessageBox.Show("Cannot be divided by 0", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return 0;
                }
                return a / b;
            }
        }
    }
}