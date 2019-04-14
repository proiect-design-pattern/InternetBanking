using InternetBanking.CreationalPatterns.Singleton;

namespace InternetBanking.CreationalPatterns.Factory.Interfaces
{
   public interface ICurrencyProfile
    {
        ClientAccount Client { get; set; }
        ECurrencyProfile profileCurrency { get; set; }
        void Deposit(double value);

    }
}
