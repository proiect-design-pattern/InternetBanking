using InternetBanking.Utils.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternetBanking.CreationalPatterns.Factory;
using InternetBanking.CreationalPatterns.Factory.Interfaces;
using InternetBanking.CreationalPatterns.Singleton;
using InternetBanking.StructuralPatterns;

namespace InternetBanking
{
   class Program
   {
      private static int sw;
      private static String input;
      static void Main(string[] args)
      {
         SafeAccountProxy safeAccount = new SafeAccountProxy();
         safeAccount.RealSubject = ClientAccount.Instance();
         
         ICurrencyProfile eurProfile = new CurrencyEUR {
            Client = safeAccount.RealSubject,
            ProfileCurrency =  ECurrencyProfile.EUR
         };
         eurProfile.Deposit(1000);
         ICurrencyProfile ronProfile = new CurrencyEUR {
            Client = safeAccount.RealSubject,
            ProfileCurrency = ECurrencyProfile.RON
         };
         ronProfile.Client.Deposit(200);
         ICurrencyProfile usdProfile = new CurrencyEUR {
            Client = safeAccount.RealSubject,
            ProfileCurrency = ECurrencyProfile.USD
         };
         usdProfile.Client.Deposit(140);

         Console.WriteLine("1: Schimbă parola:" + "\n");
         Console.WriteLine("2: Curs de schimb valutar" + "\n");
         Console.WriteLine("3: Schimb valutar" + "\n");
         Console.WriteLine("4: Trimite bani" + "\n");
         Console.WriteLine("5: Plătește factură utilități" + "\n");
         Console.WriteLine("6: Reîncarcă o cartelă telefonică" + "\n");
         Console.WriteLine("7: Cumpără rovignetă" + "\n");
         Console.WriteLine("8: Administrează depozitele tale" + "\n");
         Console.WriteLine("9: Locații și unități ATM" + "\n");
         Console.WriteLine("0: Log out");

         ReadInputCommand();
         while (sw > 0)
         {
            switch (sw) {
               case 1: {
                  Console.WriteLine("Introdu parola:");
                  string password = Console.ReadLine();
                  safeAccount.Activate(password);
                  break;
               }

               case 2: {
                  XmlReader.PrintCurrency();
                  break;
               }

               case 3:

               case 4:

               case 5:

               case 6:

               case 7:

               case 8:

               case 9:

               case 0:

               default:
                  ReadInputCommand();
                  break;
            }

         }

      }

      private static void ReadInputCommand()
      {
         Console.WriteLine("Opțiunea dumneavoastra: ");
         input = Console.ReadLine();
         sw = -1;
         Int32.TryParse(input, out sw);
      }
   }
}
