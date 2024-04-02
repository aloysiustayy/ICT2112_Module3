using DomainLayer.Entity;
using DomainLayer.Interface;
using DomainLayer.Factory;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DomainLayer.Control
{
    public class ChatControl
    {
        private readonly IChatTDG _chatTDG;
        private readonly IMessageFactory _messageFactory;

        public ChatControl(IChatTDG chatTDG, IMessageFactory messageFactory)
        {
            _chatTDG = chatTDG;
            _messageFactory = messageFactory;
        }

        public void SendMessage(int senderId, int receiverId, string messageContent)
        {
            var textMessage = _messageFactory.CreateMessage(senderId, receiverId, messageContent) as TextMessage;

            if (textMessage != null)
            {
                _chatTDG.InsertMessage(textMessage);
            }
        }

        public List<TextMessage> RetrieveMessages(int userId, int chatPartnerId)
        {
            return _chatTDG.GetMessagesBetweenUsers(userId, chatPartnerId);
        }
    }
}