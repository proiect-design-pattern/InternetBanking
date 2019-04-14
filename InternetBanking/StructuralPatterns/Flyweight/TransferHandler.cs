using InternetBanking.Utils.PublicEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternetBanking.StructuralPatterns.Flyweight.Currencies;
using InternetBanking.StructuralPatterns.Flyweight.RegisterHandlers;

namespace InternetBanking.StructuralPatterns.Flyweight
{
   public abstract class TransferHandler
   {
      public EurTransferHandler TEurTransfer { get; set; }
      public RonTransferHandler TRonTransfer { get; set; }
      public UsdTransferHandler TUsdTransfer { get; set; }
      public abstract Money CreateNewMoney();

      public TransferHandler()
      {
         TEurTransfer = new EurTransferHandler();
         TRonTransfer = new RonTransferHandler();
         TUsdTransfer = new UsdTransferHandler();
      }

      public void CashOut(ECurrency fromCurrency, ECurrency toCurrency, double value)
      {
         GetTransferHandler(fromCurrency).CacheOut(toCurrency, value);
      }
      private ITransferRegister GetTransferHandler(ECurrency type)
      {
         ITransferRegister handlerRegister = null;
         switch (type) {
            case ECurrency.EUR: {
               handlerRegister = TEurTransfer;
               break;
            }
            case ECurrency.RON: {
               handlerRegister = TRonTransfer;
               break;
            }
            case ECurrency.USD: {
               handlerRegister = TUsdTransfer;
               break;
            }
         }

         return handlerRegister;
      }
   }
}

