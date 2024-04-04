using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Interface
{
    public interface ITextMessageObservable
    {
        void Attach(ITextMessageObserver observer);
        void Detach(ITextMessageObserver observer);
        void Notify();
    }
}
