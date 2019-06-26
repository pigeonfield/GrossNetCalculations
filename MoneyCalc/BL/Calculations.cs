using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyCalc.BL
{
    public static class Calculations
    {
        public static double FromNetToGross(double amount, double vat, double tax)
        {
            double result = (amount * (1 + vat / 100)) / ((100 - tax) / 100);
            return result;                     
        }

        public static double FromGrossToNet(double amount, double vat, double tax)
        {            
            double result = ((100 - tax) / 100) * (amount / (1 + (vat / 100)));
            return result;
        }
    }
}
