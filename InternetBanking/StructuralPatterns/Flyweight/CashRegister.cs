using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetBanking.StructuralPatterns.Flyweight
{
    public abstract class CashRegister
    {
        public abstract Money CreateNewMoney();
        public void CashOut(double value)
        {
            //
        }
    }
}
