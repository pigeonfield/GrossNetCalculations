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
            VAT.ItemsSource = new List<string> {"No VAT" , "5%", "7%", "8%", "22%", "23%"};
            Tax.ItemsSource = new List<string> { "No TAX", "9%", "18%", "32%"};
        }


        private void BtnCountFromNet_Click(object sender, RoutedEventArgs e)
        {
            var input = txtInput.Text;
            double amount;
            if (Double.TryParse(input, out amount)) 
            {
                amount = Double.Parse(input);
                double vat = ConvertToCountableType.GetCountableValue(VAT.Text);
                double tax = ConvertToCountableType.GetCountableValue(Tax.Text);
                double result = Math.Round((Calculations.FromNetToGross(amount, vat, tax)), 2);
                txtOutput.Text = $"Kwota brutto - {result.ToString()} PLN";
            }
            else
            {
                MessageBox.Show("Wpisz wartość numeryczną!");
            }

            
        }

        private void BtnCountFromGross_Click(object sender, RoutedEventArgs e)
        {
            var input = txtInput.Text;
            double amount;
            if (Double.TryParse(input, out amount))
            {
                amount = Double.Parse(input);
                double vat = ConvertToCountableType.GetCountableValue(VAT.Text);
                double tax = ConvertToCountableType.GetCountableValue(Tax.Text);
                double result = Math.Round((Calculations.FromGrossToNet(amount, vat, tax)), 2);
                txtOutput.Text = $"Kwota netto - {result.ToString()} PLN";
            }
            else
            {
                MessageBox.Show("Wpisz wartość numeryczną!");
            }

            
        }
    }
}

