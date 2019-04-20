using InternetBanking.CreationalPatterns.Factory;
using InternetBanking.CreationalPatterns.Factory.Interfaces;
using InternetBanking.CreationalPatterns.Singleton;
using InternetBanking.StructuralPatterns;
using InternetBanking.StructuralPatterns.Flyweight;
using InternetBanking.Utils.Helpers;
using InternetBanking.Utils.PublicEnums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InternetBanking
{
   class Program
   {
      private static int sw;
      private static String input;
      private static Dictionary<string, KeyValuePair<string, string>> BrasovLocations = new Dictionary<string, KeyValuePair<string, string>>();
      private static List<string> IBANs = new List<string>();
      private static List<int> valoriCartela = new List<int>(){2, 4, 5, 6, 8, 10, 12};
      private static Random random = new Random();
      private static int valFactura = random.Next(10, 150);
      static void Main(string[] args)
      {
         #region Creational Patterns
         SafeAccountProxy safeAccount = new SafeAccountProxy();//there is only one account used per mobile device
         safeAccount.RealSubject = ClientAccount.Instance();
         safeAccount.Deposit(1000, 5000, 2000);

         ICurrencyProfile eurProfile = new CurrencyEUR {
            Client = ClientAccount.Instance(),
            ProfileCurrency = ECurrencyProfile.EUR
         };

         ICurrencyProfile ronProfile = new CurrencyEUR {
            Client = ClientAccount.Instance(),
            ProfileCurrency = ECurrencyProfile.RON
         };

         ICurrencyProfile usdProfile = new CurrencyEUR {
            Client = ClientAccount.Instance(),
            ProfileCurrency = ECurrencyProfile.USD
         };

         #endregion
         ConstructBrasovLocations();
         ConstructIBANs();
         XmlReader.ReadCurrency();
         LoginToAccount(safeAccount, out sw);

         while (sw >= 0) {
            switch (sw) {
               //Change password
               case 1: {
                     Console.WriteLine("Introdu parola:");
                     string password = Console.ReadLine();
                     safeAccount.Activate(password);
                     break;
                  }
               //See currencies
               case 2: {
                     XmlReader.PrintCurrency();
                     break;
                  }
               //Exchange
               case 3: {
                     Exchange();
                     break;
                  }
               //Send money to another account 
               case 4: {
                     string iban = null;
                     ICurrencyProfile profile = null;
                     while (true) {
                        Console.WriteLine("Dati contul IBAN in care doriti sa faceti depunerea:");
                        iban = Console.ReadLine();
                        if (IBANs.Contains(iban)) {
                           break;
                        } else {
                           Console.WriteLine("Cont iban inexistent!");
                        }
                     }
                     Console.WriteLine("Dati suma:");
                     Double.TryParse(Console.ReadLine(), out double sum);
                     Console.WriteLine("Alegeti contul din care sa se retraga suma: eur, ron sau usd");
                     string option = Console.ReadLine();
                     option = option.Trim().ToUpper();
                     switch (option) {
                        case "EUR": {
                              profile = eurProfile;
                              break;
                           }
                        case "RON": {
                              profile = ronProfile;
                              break;
                           }
                        case "USD": {
                              profile = usdProfile;
                              break;
                           }
                        default: {
                              Console.WriteLine("Pentru contul dumneavoastra sunt disponibile doar 3 profile: Euro, Dolar si Ron");
                              break;
                           }
                     }

                     if (profile != null) {
                        profile.SendMoney(iban, sum);
                     }
                     break;
                  }

               case 5: {
                     Console.WriteLine("Introduceti cifrele codului de bare de pe factura:");
                     Int32.TryParse(Console.ReadLine(), out int code);
                     Console.WriteLine("Alegeti tipul facturii: 1-Electricitate, 2-Apa, 3-Telefon, 4-Gaz");
                     Int32.TryParse(Console.ReadLine(), out int option);
                     EBillType type = EBillType.NO_BILL;
                     switch (option) {
                        case 1: {
                              type = EBillType.EElectricityBill;
                              break;
                           }
                        case 2: {
                              type = EBillType.EWaterBill;
                              break;
                           }
                        case 3: {
                              type = EBillType.EPhoneBill;
                              break;
                           }
                        case 4: {
                              type = EBillType.EGasBill;
                              break;
                           }
                        default: {
                              Console.WriteLine("Optiunea este momentan indisponibila.");
                              break;
                           }
                     }

                     if (type != EBillType.NO_BILL) {
                        string randomIBAN = IBANs.ElementAt(random.Next(0, IBANs.Count));
                        ronProfile.SendMoney(randomIBAN, valFactura);
                        Console.WriteLine($"{type.ToString()} : A fost retrasa suma de {valFactura} ron.");
                     }
                     break;
                  }

               case 6: {
                     Console.WriteLine("Alegeti reteaua: 1-Telekom, 2-Vodafone, 3-Digi, 4-Orange");
                     Int32.TryParse(Console.ReadLine(), out int optionResult);
                     Console.WriteLine("Introduceti numarul de telefon:");
                     Int32.TryParse(Console.ReadLine(), out int phone);
                     EMobilePhoneNetwork network = EMobilePhoneNetwork.NO_AVAIBLE_NETWORK;
                     switch (optionResult) {
                        case 1:
                        {
                           network = EMobilePhoneNetwork.Telekom;
                              break;
                           }
                        case 2: {
                           network = EMobilePhoneNetwork.Vodafone;
                           break;
                        }
                        case 3: {
                           network = EMobilePhoneNetwork.Digi;
                           break;
                        }
                        case 4: {
                           network = EMobilePhoneNetwork.Orange;
                           break;
                        }
                        default: {
                           Console.WriteLine("Momentan nu se pot face plati in reteaua aleasa.");
                           break;
                        }
                     }

                     if (network != EMobilePhoneNetwork.NO_AVAIBLE_NETWORK)
                     {
                        string randomIBAN = IBANs.ElementAt(random.Next(0, IBANs.Count));
                        int valCartela = valoriCartela.ElementAt(random.Next(0, valoriCartela.Count));
                        eurProfile.SendMoney(randomIBAN, valCartela);
                        Console.WriteLine($"Reincarcare cartela {network.ToString()} : A fost retrasa suma de {valCartela} eur.");
                     }
                     break;
                  }

               //Balance from all accounts
               case 7: {
                     safeAccount.DisplayBalance();
                     break;
                  }

               case 8: {
                     PrintAgencies();
                     break;
                  }
               case 0: {
                     LoginToAccount(safeAccount, out sw);
                     break;
                  }

               default:
                  ReadInputCommand(out sw);
                  break;
            }

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Doriti sa continuati? y - yes, n - no");
            if (Char.TryParse(Console.ReadLine(), out char opt)) {
               if (opt == 'y') {
                  ReadInputCommand(out sw);
               } else {
                  sw = 0;
               }
            }

         }

      }

      private static void Exchange()
      {
         Console.WriteLine("Schimb Valutar:");
         Console.WriteLine("Dati moneda curenta: (max. 3 litere)");
         string fCurrency = Console.ReadLine();
         Console.WriteLine("Dati moneda in care doriti sa se faca schimbul valutar: (max. 3 litere)");
         string tCurrency = Console.ReadLine();
         Console.WriteLine("Dati suma pe care doriti sa o cumparati:");
         bool ok = Double.TryParse(Console.ReadLine(), out double val);
         ECurrency fromCurrency = ECurrency.NO_CURRENCY;
         ECurrency toCurrency = ECurrency.NO_CURRENCY;
         ProcessInput(fCurrency, ref fromCurrency, tCurrency, ref toCurrency);
         if (ok) {
            TransferHandler handler = new TransferHandler();
            handler.CashOut(fromCurrency, toCurrency, val);
         }
      }

      private static void ProcessInput(string fCurrency, ref ECurrency fromCurrency, string tCurrency, ref ECurrency toCurrency)
      {
         fCurrency = fCurrency.ToUpper().Trim();
         tCurrency = tCurrency.ToUpper().Trim();
         AssignValue(tCurrency, ref toCurrency);
         AssignValue(fCurrency, ref fromCurrency);
      }

      private static void AssignValue(string input, ref ECurrency currency)
      {
         switch (input) {
            case "EUR": {
                  currency = ECurrency.EUR;
                  break;
               }
            case "USD": {
                  currency = ECurrency.USD;
                  break;
               }
            case "RON": {
                  currency = ECurrency.RON;
                  break;
               }
            default: {
                  currency = ECurrency.NO_CURRENCY;
                  break;
               }
         }
      }

      private static void ReadInputCommand(out int sw)
      {
         Console.ForegroundColor = ConsoleColor.Blue;
         Console.WriteLine("\n1: Schimba parola:" + "\n");
         Console.WriteLine("2: Curs de schimb valutar" + "\n");
         Console.WriteLine("3: Schimb valutar" + "\n");
         Console.WriteLine("4: Trimite bani" + "\n");
         Console.WriteLine("5: Plateste factura utilitati" + "\n");
         Console.WriteLine("6: Reincarca o cartela telefonica" + "\n");
         //Console.WriteLine("7: Cumpara rovigneta" + "\n");
         Console.WriteLine("7: Sold Curent toate conturile" + "\n");
         Console.WriteLine("8: Locatii si unitati ATM" + "\n");
         Console.WriteLine("0: Log out");
         Console.ForegroundColor = ConsoleColor.Green;
         Console.WriteLine("Optiunea dumneavoastra: ");
         input = Console.ReadLine();
         sw = -1;
         Int32.TryParse(input, out sw);
      }

      private static void LoginToAccount(SafeAccountProxy safeAccount, out int sw)
      {
         Console.ForegroundColor = ConsoleColor.Yellow;
         bool ok = false;
         System.Console.Write("Introduceti parola: ");
         while (ok == false) {
            var password = Util.GetHiddenConsoleInput();
            if (safeAccount.Login(password)) {
               ok = true;
            }
         }
         ReadInputCommand(out sw);
      }

      private static void ConstructBrasovLocations()
      {
         BrasovLocations.Add("Agentia Grivitei", new KeyValuePair<string, string>("Strada Grivitei, nr. 47", "Brasov 400027, judetul Brasov"));
         BrasovLocations.Add("Sucursala", new KeyValuePair<string, string>("Strada 13 Decembrie, nr. 17", "Brasov 400027, judetul Brasov"));
         BrasovLocations.Add("Agentia My Place", new KeyValuePair<string, string>("Bd. Garii, nr. 7, My Place", "Brasov 400027, judetul Brasov"));
         BrasovLocations.Add("Agentia Tractorul", new KeyValuePair<string, string>("Strada 1 Decembrie 1918, nr. 8", "Brasov 400027, judetul Brasov"));
         BrasovLocations.Add("Brasov", new KeyValuePair<string, string>("Bd. Garii, nr. 1, Statia CFR", "Brasov 400027, judetul Brasov"));
         BrasovLocations.Add("Agentia Divizia de Medici", new KeyValuePair<string, string>("Strada Iuliu Maniu, nr. 49, corp 1", "Brasov 400027, judetul Brasov"));
         BrasovLocations.Add("Agentia Brasov", new KeyValuePair<string, string>("Strada Turnului, nr. 5, Coresi Bussines Park", "Brasov 400027, judetul Brasov"));
         BrasovLocations.Add("Agentia Astra", new KeyValuePair<string, string>("Calea Bucuresti, nr. 10B, parter", "Brasov 400027, judetul Brasov"));
         BrasovLocations.Add("Agentie langa farmacia Sensiblu", new KeyValuePair<string, string>("Bulevardul Eroilor, nr. 17", "Brasov 400027, judetul Brasov"));
         BrasovLocations.Add("Agentia Centru vechi", new KeyValuePair<string, string>("Strada Jepilor, nr. 2, nr. 47", "Brasov 500256, judetul Brasov"));
      }

      private static void ConstructIBANs()
      {
         IBANs.Add("RO55CQKV6661958528122359");
         IBANs.Add("RO79BFOC2351196617735741");
         IBANs.Add("RO31DDUI6713562666743712");
         IBANs.Add("RO83CGCF1657216983376568");
         IBANs.Add("RO15NGPJ8267193797759516");
         IBANs.Add("RO82YKZY2722389787122933");
         IBANs.Add("RO74EZCK9969588934373694");
         IBANs.Add("RO24OIHS7521849885297433");
         IBANs.Add("RO50QDIP4839127497711426");
         IBANs.Add("RO53TVBT5388838585597576");
      }

      private static void PrintAgencies()
      {
         foreach (KeyValuePair<string, KeyValuePair<string, string>> element in BrasovLocations) {
            Console.WriteLine($"\t{element.Key} -> {element.Value.Key}\n\t\t\t -> {element.Value.Value}");
         }
      }
   }
}
