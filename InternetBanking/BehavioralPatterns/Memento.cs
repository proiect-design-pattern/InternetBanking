using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetBanking.BehavioralPatterns
{
   public class Memento
   {
        public int State { get; set; }
        public Memento(int state)
        {
            this.State = state;
        }
   }
}
