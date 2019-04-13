using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetBanking.BehavioralPatterns
{
    class Caretaker
    {
        private Dictionary<string, Memento> _keyPointState = new Dictionary<string, Memento>();
        public void AddKeyState ( string description, Memento memento)
        {
            _keyPointState.Add(description, memento);
        }
        public bool RemoveKeyState( string description)
        {
            return _keyPointState.Remove(description);

        }
    }
}
