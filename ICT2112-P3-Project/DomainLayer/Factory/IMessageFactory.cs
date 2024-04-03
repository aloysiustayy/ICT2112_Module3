using DomainLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Factory
{
    public interface IMessageFactory
    {
        IMessage CreateMessage(int senderId, int receiverId, string messageContent);
    }
}