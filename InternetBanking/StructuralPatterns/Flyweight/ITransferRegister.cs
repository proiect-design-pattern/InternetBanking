using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using InternetBanking.StructuralPatterns.Flyweight.Currencies;
using InternetBanking.Utils.PublicEnums;

namespace InternetBanking.StructuralPatterns.Flyweight
{
   public interface ITransferRegister
   {
       void CacheOut(ECurrency toCurrency, double val);
   }
}
