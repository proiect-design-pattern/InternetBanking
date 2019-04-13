using InternetBanking.Utils.PublicEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetBanking.StructuralPatterns.Flyweight
{
    class TransferHandler
    {
        private RegisterMoney _cardMoney;
        public TransferHandler()
        {
            _cardMoney = new RegisterMoney();
        }
        public void CashOut(ECurrency currency , double value)
        {
            switch (currency)
            {
                case ECurrency.CHF:
                    {
                        _cardMoney.CashOut(value);
                        break;
                    }
                case ECurrency.EUR:
                    {
                        _cardMoney.CashOut(value);
                        break;
                    }
                case ECurrency.GPB:
                    {
                        _cardMoney.CashOut(value);
                        break;
                    }
                case ECurrency.RUB:
                    {
                        _cardMoney.CashOut(value);
                        break;
                    }
                case ECurrency.SEK:
                    {
                        _cardMoney.CashOut(value);
                        break;
                    }
                case ECurrency.USD:
                    {
                        _cardMoney.CashOut(value);
                        break;
                    }
                default:
                    {
                        Console.WriteLine("This type of currency doesn't exist in our database");
                        break;
                    }
            }
        }
    }
}
