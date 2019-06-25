using MoneyCalc.BL;
using MoneyCalc.Converters;
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

namespace MoneyCalc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       

        public MainWindow()
        {
            InitializeComponent();
            VAT.ItemsSource = new List<string> { "5%", "7%", "8%", "22%", "23%", "No VAT" };
            Tax.ItemsSource = new List<string> { "9%", "18%", "32%", "No TAX" };
        }


        private void BtnCountFromNet_Click(object sender, RoutedEventArgs e)
        {
            var input = txtInput.Text;
            double amount = Double.Parse(input);
            double vat = ConvertToCountableType.GetCountableValue(VAT.Text);
            double tax = ConvertToCountableType.GetCountableValue(Tax.Text);
            double result = Calculations.FromNetToGross(amount, vat, tax);
            txtOutput.Text = $"Brutto is {result.ToString()}";
        }

        private void BtnCountFromGross_Click(object sender, RoutedEventArgs e)
        {
            var input = txtInput.Text;
            double amount = Double.Parse(input);
            double vat = ConvertToCountableType.GetCountableValue(VAT.Text);
            double tax = ConvertToCountableType.GetCountableValue(Tax.Text);
            double result = Calculations.FromGrossToNet(amount, vat, tax);
            txtOutput.Text = $"Netto is {result.ToString()}";
        }
    }
}

