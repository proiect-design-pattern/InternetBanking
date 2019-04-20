using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternetBanking.StructuralPatterns.Flyweight.Currencies;
using InternetBanking.Utils.Helpers;
using InternetBanking.Utils.PublicEnums;

namespace InternetBanking.StructuralPatterns.Flyweight.RegisterHandlers
{
   public class EurTransferHandler : ITransferRegister
   {
      private Money money;
      public EurTransferHandler()
      {
         money = new EURMoney();
      }
      public void CacheOut(ECurrency toCurrency, double val)
      {
         KeyValuePair<double, int> usdPair;
         KeyValuePair<double, int> eurPair;
         double sumInRon;

         XmlReader.ExchangeRates.TryGetValue(ECurrency.USD.ToString(), out usdPair);
         XmlReader.ExchangeRates.TryGetValue(ECurrency.EUR.ToString(), out eurPair);
         sumInRon = (double) (val / eurPair.Key);

         switch (toCurrency) {
            case ECurrency.USD:
               money.TotalCacheValue = (double) (sumInRon * usdPair.Key);
               break;
            case ECurrency.EUR:
               money.TotalCacheValue = val;
               break;
            case ECurrency.RON:
               money.TotalCacheValue = sumInRon;
               break;
         }
         Console.WriteLine($"{money.TotalCacheValue} {ECurrency.EUR}");

      }
   }
}
