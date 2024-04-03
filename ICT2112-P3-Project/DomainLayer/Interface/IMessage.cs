using System;

namespace DomainLayer.Entity
{
    public interface IMessage
    {
        int id { get; set; }
        int sender_id { get; set; }
        int receiver_id { get; set; }
        DateTime created_at { get; set; }
    }
}