using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SimpleCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private String _displayText = "";
        private TextBox _displayTextBox;

        public MainWindow()
        {
            InitializeComponent();

            _displayTextBox = (TextBox)FindName("Display");
            _displayTextBox.Text = "0";
        }

        private void UpdateDisplay()
        {
            _displayTextBox.Text = _displayText;
        }

        private void Calculate()
        {
            if (_displayText.Length == 0)
            {
                return;
            }

            if (_displayText.Contains('+'))
            {
                String[] numbers = _displayText.Split('+');
                _displayText = (Convert.ToDouble(numbers[0]) + Convert.ToDouble(numbers[1])).ToString();
            }
            else if (_displayText.Contains('-'))
            {
                String[] numbers = _displayText.Split('-');
                _displayText = (Convert.ToDouble(numbers[0]) - Convert.ToDouble(numbers[1])).ToString();
            }
            else if (_displayText.Contains('*'))
            {
                String[] numbers = _displayText.Split('*');
                _displayText = (Convert.ToDouble(numbers[0]) * Convert.ToDouble(numbers[1])).ToString();
            }
            else if (_displayText.Contains('/'))
            {
                String[] numbers = _displayText.Split('/');
                _displayText = (Convert.ToDouble(numbers[0]) / Convert.ToDouble(numbers[1])).ToString();
            }

            if (_displayText.EndsWith(".0"))
            {
                _displayText = _displayText.Substring(0, _displayText.Length - 2);
            }

            UpdateDisplay();
        }

        private void ClickResult(object sender, RoutedEventArgs e)
        {
            Calculate();
        }

        private void ClickClear(object sender, RoutedEventArgs e)
        {
            _displayText = "0";
            UpdateDisplay();
        }

        private void ClickNumber(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            _displayText += button.Content.ToString();
            UpdateDisplay();
        }

        private void ClickOperator(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            if (_displayText.Length == 0)
            {
                return;
            }

            if (_displayText.Contains('+') || _displayText.Contains('-') || _displayText.Contains('*') || _displayText.Contains('/'))
            {
                Calculate();
            }

            _displayText += button.Content.ToString();
            UpdateDisplay();
        }
    }
}
