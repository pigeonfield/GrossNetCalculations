using MoneyCalc.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MoneyCalc.Commands
{
    public class FromNetToGrossCommand : ICommand, INotifyPropertyChanged
    {
        public event EventHandler CanExecuteChanged;
        //public event EventHandler<double> AmountChanged;
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly Func<double> getValueFromInputCallback;

        private readonly Action<double> sendOutputCallback;

        private double _amount;
        public double Amount
        {
            get { return _amount; }
            set
            {
                _amount = value;
                NotifyPropChanged(nameof(Amount));
            }
        }

        public double result;
        

        public FromNetToGrossCommand(Func<double> getValueFromInputCallback, Action<double> sendOutputCallback)
        {
            this.getValueFromInputCallback = getValueFromInputCallback;
            this.sendOutputCallback = sendOutputCallback;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Amount = getValueFromInputCallback();
            //AmountChanged(this, Amount);
            double result = Math.Round((Calculations.FromNetToGross(Amount, 23.00, 18.00)), 2);
            //MessageBox.Show(result.ToString());
            sendOutputCallback(result);
            
        }

        private void NotifyPropChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
