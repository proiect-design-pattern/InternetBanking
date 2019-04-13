using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetBanking.BehavioralPatterns
{
    class Tranzactie
    {
        public int State { get; set; }
        public Tranzactie( int state)
        {
            this.State = state;
        }
        public Memento SavetToMemento()
        {
            return new Memento( State );

        }
        public void RestoreFromMemento(Memento memento)
        {
            State = memento.State;
        }
        public void Display()
        {
            Console.WriteLine("Current value: " + State);
        }
    }
}
