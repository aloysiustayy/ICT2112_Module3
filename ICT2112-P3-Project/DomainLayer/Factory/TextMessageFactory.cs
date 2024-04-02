using DomainLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Factory
{
    public class TextMessageFactory : IMessageFactory
    {
        public IMessage CreateMessage(int senderId, int receiverId, string messageContent)
        {
            return new TextMessage
            {
                sender_id = senderId,
                receiver_id = receiverId,
                message = messageContent,
                created_at = DateTime.Now
            };
        }
    }
}
