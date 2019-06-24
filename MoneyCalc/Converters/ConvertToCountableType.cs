using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MoneyCalc.Converters
{
    public static class ConvertToCountableType
    {
        public static double GetCountableValue(this string value)
        {
            double countableValue = (value[0] != 'N') ? Double.Parse(value.Remove(value.Length - 1, 1)): 0.00;
            return countableValue;
        }
    }
}
