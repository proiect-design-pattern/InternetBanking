using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetBanking.Utils.Helpers
{
   public static class Util
   {
      public static string GetHiddenConsoleInput()
      {
         StringBuilder input = new StringBuilder();
         while (true) {
            var key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.Enter)
               break;
            if (key.Key == ConsoleKey.Backspace && input.Length > 0) {
               input.Remove(input.Length - 1, 1);
            } else if (key.Key != ConsoleKey.Backspace) {
               Console.Write("*");
               input.Append(key.KeyChar);
            }
         }
         return input.ToString().ToLower();
      }
   }
}
