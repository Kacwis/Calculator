using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calulator
{
    class CalculatorLogics
    {
        
        public static CalculatorLogics CALCULATORLOGICS = new CalculatorLogics();

        private CalculatorLogics() { }

        public double addding(double basis, double toAdd)
        {
            return basis + toAdd;
        }
      
        public double substracting(double basis, double toSubstract)
        {
            return basis - toSubstract;
        }
  
        public double multiplaying(double basis, double toMultiply)
        {
            return basis * toMultiply;
        }

        public double dividing(double basis, double toDivide)
        {
            if (toDivide == 0)
                return 0;
            return basis / toDivide;
        }
      
        public double minusOrPlus(double number)
        {
            return (number * -1);
        }

        public double upTo2Powers(double number)
        {
            return Math.Pow(number, 2);
        }
    }
}
