using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternetBanking.StructuralPatterns.Interfaces;

namespace InternetBanking.StructuralPatterns
{
   public class SafeAccountProxy :IAccount
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

      public bool Activate(string oldPassword, string newPassword)
      {
         return RealSubject.Activate(oldPassword, newPassword);
      }

      public bool Login(string password)
      {
         return RealSubject.Login(password);
      }
   }
}
