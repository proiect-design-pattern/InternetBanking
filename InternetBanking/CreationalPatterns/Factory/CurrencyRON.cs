using InternetBanking.CreationalPatterns.Factory.Interfaces;
using InternetBanking.StructuralPatterns.Interfaces;

namespace InternetBanking.CreationalPatterns.Factory
{
   public class CurrencyRON : ICurrencyProfile
    {
        public IAccount Client { get; set; }
        public ECurrencyProfile ProfileCurrency { get; set; }

        public void Deposit(double value)
        {      
            Client.Deposit(value);
        }
    }
}
