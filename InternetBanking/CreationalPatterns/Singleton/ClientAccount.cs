using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternetBanking.StructuralPatterns.Interfaces;
using InternetBanking.Utils.PublicEnums;

namespace InternetBanking.CreationalPatterns.Singleton
{
   public class ClientAccount : IAccount
   {
      private readonly long _id;
      private string _password;
      private static ClientAccount _instance;

      private double EurBalance { get; set; }
      private double RonBalance { get; set; }
      private double UsdBalance { get; set; }
      public long ID
      {
         get { return _id; }
      }
      private ClientAccount()
      {
         _id = 10000;
         _password = "1q2w3e";
      }
      public static ClientAccount Instance()
      {
            object locker = new object();
            if (_instance == null) {
               lock (locker) {
                  if (_instance == null) {
                     _instance = new ClientAccount();
                  }
               }
            }
            return _instance;
      }

      public void DisplayEurBalance()
      {
         Console.WriteLine($"{EurBalance} {ECurrency.EUR}");
      }

      public void DisplayRonBalance()
      {
         Console.WriteLine($"{RonBalance} {ECurrency.RON}");
      }

      public void DisplayUsdBalance()
      {
         Console.WriteLine($"{UsdBalance} {ECurrency.USD}");
      }

      public void DepositEur(double value)
      {
         EurBalance += value;
      }

      public void DepositRon(double value)
      {
         RonBalance += value;
      }

      public void DepositUsd(double value)
      {
         UsdBalance += value; //notify
      }

      public bool TransferRon(double value)
      {
         if (value <= RonBalance)
         {
            RonBalance -= value; // notify
            return true;
         }

         return false;
      }
      public bool TransferUsd(double value)
      {
         if (value <= UsdBalance) {
            UsdBalance -= value; // notify
            return true;
         }

         return false;
      }
      public bool TransferEur(double value)
      {
         if (value <= EurBalance) {
            EurBalance -= value; // notify
            return true;
         }

         return false;
      }
      public bool Activate(string oldPassword)
      {
         Console.WriteLine("Introdu noua parola:");
         string newPassword = Console.ReadLine();
         if (Login(oldPassword))
         {
            _password = newPassword;
            return true;
         }

         return false;
      }

      public bool Login(string password)
      {
         if (_password.Equals(password))
         {
            return true;
         }

         return false;
      }
   }
}
