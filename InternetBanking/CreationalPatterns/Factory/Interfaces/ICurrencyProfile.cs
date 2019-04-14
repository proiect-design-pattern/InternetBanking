using InternetBanking.CreationalPatterns.Singleton;
using InternetBanking.StructuralPatterns.Interfaces;

namespace InternetBanking.CreationalPatterns.Factory.Interfaces
{
   public interface ICurrencyProfile
    {
        IAccount Client { get; set; }
        ECurrencyProfile ProfileCurrency { get; set; }
        void Deposit(double value);

    }
}
