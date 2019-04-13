using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetBanking.StructuralPatterns.Flyweight
{
    class RegisterMoney : CashRegister
    {
        public override Money CreateNewMoney()
        {
            return new Money();
        }
    }
}
