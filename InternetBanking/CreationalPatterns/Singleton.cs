using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternetBanking.StructuralPatterns.Interfaces;

namespace InternetBanking.CreationalPatterns
{
   public class ClientAccount : IAccount
   {
      private readonly long _id;
      private string _password;
      private static ClientAccount _instance;

      public double Balance { get; set;}

      public long ID
      {
         get { return _id; }
      }
      public ClientAccount()
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
      public void DisplayBalance()
      {
         Console.WriteLine(Balance);
      }


      public bool Activate(string oldPassword, string newPassword)
      {
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
