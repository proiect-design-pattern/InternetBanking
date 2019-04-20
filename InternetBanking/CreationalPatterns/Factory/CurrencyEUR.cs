﻿using System;
using InternetBanking.CreationalPatterns.Factory.Interfaces;
using InternetBanking.StructuralPatterns.Interfaces;

namespace InternetBanking.CreationalPatterns.Factory
{
   public class CurrencyEUR : ICurrencyProfile
    {
        public IAccount Client { get; set; }
        public ECurrencyProfile ProfileCurrency { get; set; }
        public void SendMoney(string IBAN, double value)
        {
           bool ok = Client.TransferEur(value);
           if (ok)
           {
              Console.WriteLine("Tranzactia s-a desfasurat cu succes.");
           }
           else
           {
              Console.WriteLine("Fonduri insuficiente.");
           }
        }
    }
}
