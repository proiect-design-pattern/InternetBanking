using InternetBanking.StructuralPatterns.Flyweight.Currencies;

namespace InternetBanking.StructuralPatterns.Flyweight.RegisterHandlers
{
   public class CashRegisterRON : ICashRegister
   {
      private Money money;
      public CashRegisterRON()
      {
         money = new RONMoney();
      }
      public void CacheOut(double val)
      {
         throw new System.NotImplementedException();
      }
   }
}
