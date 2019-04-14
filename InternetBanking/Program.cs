using InternetBanking.Utils.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetBanking
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlReader.ReadCurrency();
            XmlReader.Print();
        }
    }
}
