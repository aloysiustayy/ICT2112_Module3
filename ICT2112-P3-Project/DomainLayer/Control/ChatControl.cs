using DomainLayer.Entity;
using DomainLayer.Interface;
using DomainLayer.Factory;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DomainLayer.Control
{
    public class ChatControl:ITextMessageObserver
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
                textMessage.Attach(this);
                _chatTDG.InsertMessage(textMessage);
            }
        }

        public List<TextMessage> RetrieveMessages(int userId, int chatPartnerId)
        {
            var messages = _chatTDG.GetMessagesBetweenUsers(userId, chatPartnerId);
            foreach (var message in messages)
            {
                message.Attach(this); // Ensure this ChatControl is observing the message
            }
            return messages;
        }

        // Implementation of the IObserver Update method
        public void Update(ITextMessageObservable observable)
        {
            if (observable is TextMessage message)
            {
                // Update read status in the database
                _chatTDG.UpdateMessageReadStatus(message.id, true);
            }
        }

        public void MarkMessageAsRead(int messageId, int currentUserId)
        {
            var message = _chatTDG.GetMessageById(messageId); // Retrieve the message
            if (message != null && message.receiver_id == currentUserId)
            {
                message.read = true; // This will trigger the Update method via Notify
                Update(message);
            }
        }

    }
}