using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetBanking.StructuralPatterns.Interfaces
{
   public interface IAccount
   {
      void DisplayBalance();
      void Deposit(double value);
      bool Activate(string oldPassword);
      bool Login(string password);
   }
}
