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
      bool Activate(string oldPassword, string newPassword);
      bool Login(string password);
   }
}
