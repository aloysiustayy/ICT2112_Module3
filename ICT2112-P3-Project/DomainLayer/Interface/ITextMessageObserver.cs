﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Interface
{
    public interface ITextMessageObserver
    {
        void Update(ITextMessageObservable observable);
    }
}
