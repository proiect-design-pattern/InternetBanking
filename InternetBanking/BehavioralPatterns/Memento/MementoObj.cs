using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetBanking.BehavioralPatterns.Memento
{
   public class MementoObj
   {
        public int State { get; set; }
        public MementoObj(int state)
        {
            this.State = state;
        }
   }
}
