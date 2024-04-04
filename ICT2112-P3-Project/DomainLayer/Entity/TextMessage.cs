using DomainLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entity
{
    public partial class TextMessage : IMessage, ITextMessageObservable
    {
        private readonly List<ITextMessageObserver> observers = new List<ITextMessageObserver>();
        private bool _read;
        private readonly object _lock = new object();

        public bool read
        {
            get => _read;
            set
            {
                if (_read == value) return;
                _read = value;
                Notify();
            }
        }

        public void Attach(ITextMessageObserver observer)
        {
            if (observer == null) throw new ArgumentNullException(nameof(observer));

            lock (_lock)
            {
                if (!observers.Contains(observer))
                {
                    observers.Add(observer);
                }
            }
        }

        public void Detach(ITextMessageObserver observer)
        {
            if (observer == null) return;

            lock (_lock)
            {
                observers.Remove(observer);
            }
        }

        public void Notify()
        {
            List<ITextMessageObserver> localObservers;
            lock (_lock)
            {
                localObservers = new List<ITextMessageObserver>(observers);
            }

            foreach (var observer in localObservers)
            {
                try
                {
                    observer.Update(this);
                }
                catch
                {
                    // Log or handle the error as appropriate
                }
            }
        }

        public int id { get; set; }
        public int sender_id { get; set; }
        public int receiver_id { get; set; }
        public string message { get; set; }
        public DateTime created_at { get; set; }
    }
}