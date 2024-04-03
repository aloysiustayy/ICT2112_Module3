using DomainLayer.Entity;
using System.Collections.Generic;

namespace PresentationLayer.ViewModel
{
    public class ChatViewModel
    {
        public int CurrentUserId { get; set; }
        public int ChatPartnerId { get; set; }
        public string ChatPartnerName { get; set; }
        public List<TextMessage> Messages { get; set; } = new List<TextMessage>();
    }
}