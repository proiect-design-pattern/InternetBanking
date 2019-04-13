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
            Console.WriteLine("1: Schimbă parola:"+"\n");
            Console.WriteLine("2: Curs de schimb valutar"+"\n");
            Console.WriteLine("3: Schimb valutar"+"\n");
            Console.WriteLine("4: Trimite bani"+"\n");
            Console.WriteLine("5: Plătește factură utilități"+"\n");
            Console.WriteLine("6: Reîncarcă o cartelă telefonică"+"\n");
            Console.WriteLine("7: Cumpără rovignetă"+"\n");
            Console.WriteLine("8: Administrează depozitele tale"+"\n");
            Console.WriteLine("9: Locații și unități ATM"+"\n");
            Console.WriteLine("0: Log out");

            
            Console.WriteLine("Opțiunea dumneavoastră: ");
            String input = Console.ReadLine();
            int sw;
            Int32.TryParse(input, out sw);

            switch (sw)
            {
                case 1:

                case 2:

                case 3:

                case 4:

                case 5:

                case 6:

                case 7:

                case 8:

                case 9:

                case 0:

                default:
                    "Alegeți o variantă"
            }
        }
    }
}
