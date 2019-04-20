using InternetBanking.StructuralPatterns.Interfaces;
using InternetBanking.Utils.Helpers;
using System;

namespace InternetBanking.StructuralPatterns
{
   public class SafeAccountProxy : IAccount
   {
      public IAccount RealSubject { get; set; }
      public void DisplayBalance()
      {
         Console.WriteLine("Give me the password:");
         string userPass = Util.GetHiddenConsoleInput();
         if (Login(userPass)) {
            Console.WriteLine();
            RealSubject.DisplayUsdBalance();
            RealSubject.DisplayEurBalance();
            RealSubject.DisplayRonBalance();
         } else {
            Console.WriteLine("Wrong password");
         }
      }

      public void Deposit(double eur, double ron, double usd)
      {
         DepositEur(eur);
         DepositRon(ron);
         DepositUsd(usd);
      }
      public void DisplayEurBalance()
      {
         RealSubject.DisplayEurBalance();
      }

      public void DisplayRonBalance()
      {
         RealSubject.DisplayRonBalance();
      }

      public void DisplayUsdBalance()
      {
         RealSubject.DisplayUsdBalance();
      }

      public void DepositEur(double value)
      {
         RealSubject.DepositEur(value);
      }

      public void DepositRon(double value)
      {
         RealSubject.DepositRon(value);
      }

      public void DepositUsd(double value)
      {
         RealSubject.DepositUsd(value);
      }

      public bool TransferEur(double value)
      {
         throw new NotImplementedException();
      }

      public bool TransferRon(double value)
      {
         throw new NotImplementedException();
      }

      public bool TransferUsd(double value)
      {
         throw new NotImplementedException();
      }

      public bool Activate(string oldPassword)
      {
         return RealSubject.Activate(oldPassword);
      }

      public bool Login(string password)
      {
         return RealSubject.Login(password);
      }
   }
}
