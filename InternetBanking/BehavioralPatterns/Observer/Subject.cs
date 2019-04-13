using InternetBanking.BehavioralPatterns.Observer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternetBanking.CreationalPatterns;

namespace InternetBanking.BehavioralPatterns.Observer
{
    public class Subject:ISubject
    {
        private List<Observer> observers = new List<Observer>();
        private double _previousBalance;

        public Subject(double balance)
        {
           _previousBalance = balance;//when I create the subject i give him current balance of ClientAccount
        }
        public double CurrentBalance
        {
            get
            {
                return _previousBalance;
            }
            set
            {
                if (value > _previousBalance)
                    Notify(value);
                _previousBalance = value;
            }
        }

        public void Notify(double currentBalance)
        {
            observers.ForEach(x => x.Update(currentBalance, _previousBalance));
        }

        public void Subscribe(Observer observer)
        {
            observers.Add(observer);
        }

        public void Unsubscribe(Observer observer)
        {
            observers.Remove(observer);
        }
    }
}
