﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetBanking.CreationalPatterns.Factory.Interfaces
{
    public interface ICurrencyProfile
    {
        ClientAccount Client { get; set; }
        void CurrencyType(ECurrencyProfile currencyProfile);
    }
}