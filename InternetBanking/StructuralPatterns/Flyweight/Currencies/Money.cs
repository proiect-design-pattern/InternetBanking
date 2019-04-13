using InternetBanking.Utils.PublicEnums;

namespace InternetBanking.StructuralPatterns.Flyweight.Currencies
{
   public abstract class Money
   {
      public double TotalCacheValue { get; set; }
      public abstract ECurrency GetMoneyType();

   }
}
