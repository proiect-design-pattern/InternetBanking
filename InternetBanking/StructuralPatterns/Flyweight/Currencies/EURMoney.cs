using InternetBanking.Utils.PublicEnums;

namespace InternetBanking.StructuralPatterns.Flyweight.Currencies
{
   public class EURMoney : Money
   {
      public override ECurrency GetMoneyType()
      {
         return ECurrency.EUR;
      }

   }
}
