using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetBanking.BehavioralPatterns.Memento
{
    class Tranzactie
    {
        public int State { get; set; }
        public Tranzactie( int state)
        {
            this.State = state;
        }
        public MementoObj SavetToMemento()
        {
            return new MementoObj( State );

        }
        public void RestoreFromMemento(MementoObj memento)
        {
            State = memento.State;
        }
        public void Display()
        {
            Console.WriteLine("Current value: " + State);
        }
    }
}
