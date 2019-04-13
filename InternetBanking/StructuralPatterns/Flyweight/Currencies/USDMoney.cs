using InternetBanking.Utils.PublicEnums;

namespace InternetBanking.StructuralPatterns.Flyweight.Currencies
{
   public class USDMoney : Money
   {
      public override ECurrency GetMoneyType()
      {
         return ECurrency.USD;
      }
   }
}
