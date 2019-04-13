using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using InternetBanking.StructuralPatterns.Flyweight.Currencies;

namespace InternetBanking.StructuralPatterns.Flyweight
{
   public interface ICashRegister
   {
       void CacheOut(double val);
   }
}
