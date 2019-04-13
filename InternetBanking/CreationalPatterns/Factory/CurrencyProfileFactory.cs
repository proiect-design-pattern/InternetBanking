using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetBanking.CreationalPatterns.Factory
{
    public class CurrencyProfileFactory
    {
        public ICurrencyProfile CurrencyType(ECurrencyProfile currencyProfile)
        {
            ICurrencyProfile currency = null;
            switch(currencyProfile)
            {
                case ECurrencyProfile.EUR:
                    {
                        currency = new ECurrencyProfile.EUR();
                        break;
                    }
            }
            return currency;
        }
    }
}
