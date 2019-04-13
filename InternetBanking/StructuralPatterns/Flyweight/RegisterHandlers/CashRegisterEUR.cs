using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternetBanking.StructuralPatterns.Flyweight.Currencies;

namespace InternetBanking.StructuralPatterns.Flyweight.RegisterHandlers
{
   public class CashRegisterEUR : ICashRegister
   {
      private Money money;
      public CashRegisterEUR()
      {
         money = new EURMoney();
      }
      public void CacheOut(double val)
      {
         throw new NotImplementedException();
      }
   }
}
