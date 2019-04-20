using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternetBanking.BehavioralPatterns;

namespace InternetBanking.BehavioralPatterns.Memento 
{
    class Caretaker
    {
        private Dictionary<string, MementoObj> _keyPointState = new Dictionary<string, MementoObj>();
        public void AddKeyState ( string description, MementoObj memento)
        {
            _keyPointState.Add(description, memento);
        }
        public bool RemoveKeyState( string description)
        {
            return _keyPointState.Remove(description);

        }
    }
}
