using InternetBanking.StructuralPatterns.Flyweight.Currencies;
using System;
using System.Collections.Generic;
using InternetBanking.Utils.Helpers;
using InternetBanking.Utils.PublicEnums;

namespace InternetBanking.StructuralPatterns.Flyweight.RegisterHandlers
{
   public class UsdTransferHandler : ITransferRegister
   {
      private Money money;
      public UsdTransferHandler()
      {
         money = new USDMoney();
      }
      public void CacheOut(ECurrency toCurrency, double val)
      {
         KeyValuePair<double, int> usdPair;
         KeyValuePair<double, int> eurPair;
         double sumInRon;

         XmlReader.ExchangeRates.TryGetValue(ECurrency.USD.ToString(), out usdPair);
         XmlReader.ExchangeRates.TryGetValue(ECurrency.EUR.ToString(), out eurPair);
         sumInRon = (double) (val * eurPair.Key);

         switch (toCurrency)
         {
            case ECurrency.USD:
               money.TotalCacheValue = val;
               break;
            case ECurrency.EUR:
               money.TotalCacheValue = (double) (sumInRon / usdPair.Key);
               break;
            case ECurrency.RON:
               money.TotalCacheValue = (double)(val / usdPair.Key);
               break;
         }

         Console.WriteLine($"{money.TotalCacheValue} {ECurrency.USD}");
      }
   }
}
