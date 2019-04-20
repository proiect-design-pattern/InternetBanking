using System;
using System.Collections.Generic;
using InternetBanking.StructuralPatterns.Flyweight.Currencies;
using InternetBanking.Utils.Helpers;
using InternetBanking.Utils.PublicEnums;

namespace InternetBanking.StructuralPatterns.Flyweight.RegisterHandlers
{
   public class RonTransferHandler : ITransferRegister
   {
      private Money money;
      public RonTransferHandler()
      {
         money = new RONMoney();
      }
      public void CacheOut(ECurrency toCurrency, double val)
      {
         KeyValuePair<double, int> usdPair;
         KeyValuePair<double, int> eurPair;

         XmlReader.ExchangeRates.TryGetValue(ECurrency.USD.ToString(), out usdPair);
         XmlReader.ExchangeRates.TryGetValue(toCurrency.ToString(), out eurPair);

         switch (toCurrency) {
            case ECurrency.USD:
               money.TotalCacheValue = (double) (val * usdPair.Key);
               break;
            case ECurrency.EUR:
               money.TotalCacheValue = (double) (val * eurPair.Key);
               break;
            case ECurrency.RON:
               money.TotalCacheValue = val;
               break;
         }
         Console.WriteLine($"Valoare {money.TotalCacheValue} {ECurrency.RON}");

      }
   }
}
