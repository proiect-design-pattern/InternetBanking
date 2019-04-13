using InternetBanking.StructuralPatterns.Flyweight.Currencies;
using System;

namespace InternetBanking.StructuralPatterns.Flyweight.RegisterHandlers
{
   public class CashRegisterUSD : ICashRegister
   {
      private Money money;
      public CashRegisterUSD()
      {
         money = new USDMoney();
      }
      public void CacheOut(double val)
      {
         throw new NotImplementedException();
      }
   }
}
