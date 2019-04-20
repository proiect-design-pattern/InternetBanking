using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetBanking.StructuralPatterns.Interfaces
{
   public interface IAccount
   {
      //void DisplayBalance();
      //void Deposit(double value);
      void DisplayEurBalance();
      void DisplayRonBalance();
      void DisplayUsdBalance();

      void DepositEur(double value);
      void DepositRon(double value);
      void DepositUsd(double value);

      bool TransferEur(double value);
      bool TransferRon(double value);
      bool TransferUsd(double value);

      bool Activate(string oldPassword);
      bool Login(string password);
   }
}
