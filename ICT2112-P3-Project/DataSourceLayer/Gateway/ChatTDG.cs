using DomainLayer.Entity;
using DataSourceLayer.Data;
using DomainLayer.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataSourceLayer.Gateway
{
    public class ChatTDG : IChatTDG
    {
        private readonly DataContext _context;

        public ChatTDG(DataContext context)
        {
            _context = context;
        }

        public void InsertMessage(TextMessage message)
        {
            _context.TextMessages.Add(message);
            _context.SaveChanges();
        }

        public List<TextMessage> GetMessagesBetweenUsers(int userId, int chatPartnerId)
        {
            return _context.TextMessages
                .Where(m => (m.sender_id == userId && m.receiver_id == chatPartnerId) ||
                            (m.sender_id == chatPartnerId && m.receiver_id == userId))
                .OrderBy(m => m.created_at) // This line ensures messages are sorted by their creation time
                .ToList();
        }

        public TextMessage GetMessageById(int messageId)
        {
            return _context.TextMessages.Find(messageId);
        }

        public void UpdateMessageReadStatus(int messageId, bool readStatus)
        {
            var message = _context.TextMessages.Find(messageId);
            if (message != null)
            {
                message.read = readStatus;
                _context.SaveChanges();
            }
        }

    }
}