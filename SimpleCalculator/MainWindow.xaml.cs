using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private DisplayData displayData;

        public MainWindow()
        {
            InitializeComponent();

            displayData = new DisplayData();
            DataContext = displayData;
        }


        private void Calculate()
        {
            if (displayData.Display.Length == 0)
            {
                return;
            }

            if (displayData.Display.Contains('+'))
            {
                string[] numbers = displayData.Display.Split('+');
                displayData.Display = (Convert.ToDouble(numbers[0]) + Convert.ToDouble(numbers[1])).ToString();
            }
            else if (displayData.Display.Contains('-'))
            {
                string[] numbers = displayData.Display.Split('-');
                displayData.Display = (Convert.ToDouble(numbers[0]) - Convert.ToDouble(numbers[1])).ToString();
            }
            else if (displayData.Display.Contains('*'))
            {
                string[] numbers = displayData.Display.Split('*');
                displayData.Display = (Convert.ToDouble(numbers[0]) * Convert.ToDouble(numbers[1])).ToString();
            }
            else if (displayData.Display.Contains('/'))
            {
                string[] numbers = displayData.Display.Split('/');
                displayData.Display = (Convert.ToDouble(numbers[0]) / Convert.ToDouble(numbers[1])).ToString();
            }

            if (displayData.Display.EndsWith(".0"))
            {
                displayData.Display = displayData.Display.Substring(0, displayData.Display.Length - 2);
            }
        }

        private void ClickResult(object sender, RoutedEventArgs e)
        {
            Calculate();
        }

        private void ClickClear(object sender, RoutedEventArgs e)
        {
            displayData.Display = "0";
        }

        private void ClickNumber(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            displayData.Display += button.Content.ToString();
        }

        private void ClickOperator(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            if (displayData.Display.Length == 0)
            {
                return;
            }

            if (displayData.Display.Contains('+') || displayData.Display.Contains('-') || displayData.Display.Contains('*') || displayData.Display.Contains('/'))
            {
                Calculate();
            }

            displayData.Display += button.Content.ToString();
        }
    }

    class DisplayData : INotifyPropertyChanged
    {
        private string display;

        public DisplayData() {
            display = "0";
        }

        public String Display
        {
            get { return display; }
            set
            {
                display = value;
                OnPropertyChanged("Display");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
            }
        }
    }
}
