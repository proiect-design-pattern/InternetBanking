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
      public CashRegisterEUR CashRegisterEUR { get; set; }
      public CashRegisterRON CashRegisterRON { get; set; }
      public CashRegisterUSD CashRegisterUSD { get; set; }
      public abstract Money CreateNewMoney();

      public TransferHandler()
      {
         CashRegisterEUR = new CashRegisterEUR();
         CashRegisterRON = new CashRegisterRON();
         CashRegisterUSD = new CashRegisterUSD();
      }

      public void CashOut(ECurrency currency, double value)
      {


      }
   }
   }

