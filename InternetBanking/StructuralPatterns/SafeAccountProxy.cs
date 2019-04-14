using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternetBanking.StructuralPatterns.Interfaces;

namespace InternetBanking.StructuralPatterns
{
   public class SafeAccountProxy : IAccount
   {
      public IAccount RealSubject { get; set; }
      public void DisplayBalance()
      {
         Console.WriteLine("Give me the password:");
         string userPass = Console.ReadLine();
         if (Login(userPass)) {
            RealSubject.DisplayBalance();
         } else {
            Console.WriteLine("Wrong password");
         }
      }

      public void Deposit(double value)
      {
         RealSubject.Deposit(value);
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
