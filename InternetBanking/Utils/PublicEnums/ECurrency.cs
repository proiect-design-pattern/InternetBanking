using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetBanking.Utils.PublicEnums
{
   public enum ECurrency : int
   {
      NO_CURRENCY = -1,
      /// <summary>
      /// EURO
      /// </summary>
      EUR,
      /// <summary>
      /// UNITED STATES DOLLAR
      /// </summary>
      USD,
      /// <summary>
      /// POUND STERLING
      /// </summary>
      GPB,
      /// <summary>
      /// SWISS FRANC
      /// </summary>
      CHF,
      /// <summary>
      /// RUSSIAN RUBLE
      /// </summary>
      RUB,
      /// <summary>
      /// SWEDISH KRONA
      /// </summary>
      SEK,
      /// <summary>
      /// RON
      /// </summary>
      RON,

   }
}
