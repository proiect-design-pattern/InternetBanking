using InternetBanking.CreationalPatterns.Factory.Interfaces;
using InternetBanking.CreationalPatterns.Singleton;

namespace InternetBanking.CreationalPatterns.Factory
{
   public class CurrencyUSD : ICurrencyProfile
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
