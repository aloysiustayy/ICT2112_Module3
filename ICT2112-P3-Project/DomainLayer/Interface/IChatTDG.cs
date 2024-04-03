using DomainLayer.Entity;
using System.Collections.Generic;

namespace DomainLayer.Interface
{
    public interface IChatTDG
    {
        void InsertMessage(TextMessage message);
        List<TextMessage> GetMessagesBetweenUsers(int userId, int chatPartnerId);
        void UpdateMessageReadStatus(int messageId, bool readStatus);
        TextMessage GetMessageById(int messageId);
    }
}