﻿using System;
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
      private static Dictionary<string, KeyValuePair<double, int>> _exchangeRates = new Dictionary<string, KeyValuePair<double, int>>();

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
            foreach (XmlNode node in nList)
            {
               string currency = node.Attributes.GetNamedItem("currency").ToString();
               Double.TryParse(node.InnerText, out double value);
               int multiplier = -1;
               if (node.Attributes.GetNamedItem("multiplier") != null)
               {
                  int.TryParse(node.Attributes.GetNamedItem("multiplier").Value, out multiplier);
               }
               _exchangeRates.Add(currency.Substring(10, 13), new KeyValuePair<double, int>(value, multiplier));
            }
         } catch (Exception ex) {
            Console.WriteLine();
#if DEBUG
            Debug.Print(ex.StackTrace);
#endif
         }
      }
   }
   }
}
