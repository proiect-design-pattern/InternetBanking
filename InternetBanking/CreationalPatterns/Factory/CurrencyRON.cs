using InternetBanking.CreationalPatterns.Factory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetBanking.CreationalPatterns.Factory
{
    public class CurrencyRON : ICurrencyProfile
    {
        public ClientAccount Client { get; set; }
        public ECurrencyProfile profileCurrency { get; set; }

        public void Deposit(double value)
        {
            Client = ClientAccount.Instance();
            Deposit(value);
        }
    }
}
