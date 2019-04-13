using InternetBanking.Utils.PublicEnums;

namespace InternetBanking.StructuralPatterns.Flyweight.Currencies
{
   public class RONMoney : Money
   {
      public override ECurrency GetMoneyType()
      {
         return ECurrency.RON;
      }
   }
}
