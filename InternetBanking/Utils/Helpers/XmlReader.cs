using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace InternetBanking.Utils.Helpers
{
   public class XmlReader
   {
      public static Dictionary<string, KeyValuePair<double, int>> ExchangeRates { get;} =
         new Dictionary<string, KeyValuePair<double, int>>();

      private static string URL = "http://www.bnr.ro/nbrfxrates.xml?format=xml";

      public static void ReadCurrency()
      {
         try {
            // Load the data.
            XmlDocument doc = new XmlDocument();
            doc.Load(URL);
            doc.Normalize();

            // Process the resource nodes.
            XmlNodeList nList = doc.DocumentElement.GetElementsByTagName("Rate");
            foreach (XmlNode node in nList) {
               string currency = node.Attributes.GetNamedItem("currency").Value;
               Double.TryParse(node.InnerText, out double value);
               int multiplier = -1;
               if (node.Attributes.GetNamedItem("multiplier") != null) {
                  int.TryParse(node.Attributes.GetNamedItem("multiplier").Value, out multiplier);
               }
               ExchangeRates.Add(currency, new KeyValuePair<double, int>(value, multiplier));
            }
         } catch (Exception ex) {
            Console.WriteLine();
#if DEBUG
            Debug.Print(ex.StackTrace);
#endif
         }
      }
      public static void PrintCurrency()
      {
         foreach (KeyValuePair<string, KeyValuePair<double, int>> kvp in ExchangeRates) {
            if (kvp.Value.Value != -1) {
               Console.WriteLine($"\tcurrency: {kvp.Key} with value: {kvp.Value.Key} and multiplier: {kvp.Value.Value}\n");
            }
            else
            {
               Console.WriteLine($"\tcurrency: {kvp.Key} with value: {kvp.Value.Key}\n");
            }
         }
      }
   }
}
