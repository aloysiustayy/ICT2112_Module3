using Microsoft.AspNetCore.Mvc;
using DomainLayer.Control;
using DomainLayer.Interface;
using DataSourceLayer.Data; // Assuming your DataContext is here
using PresentationLayer.ViewModel; // Update this namespace based on your project structure
using System.Linq;
using DomainLayer.Entity;
using DomainLayer.Factory;

namespace PresentationLayer.Controllers
{
    public class ChatController : Controller
    {
        private readonly ChatControl _chatControl;
        private readonly DataContext _context; // Add DataContext to access User information

        public ChatController(IChatTDG chatTDG, IMessageFactory messageFactory, DataContext context)
        {
            _chatControl = new ChatControl(chatTDG, messageFactory); // Pass messageFactory to ChatControl
            _context = context;
        }
        // Other actions remain unchanged

        public IActionResult Chat(int userId, int chatPartnerId)
        {
            var messages = _chatControl.RetrieveMessages(1, 2);
            var chatPartnerName = _context.Users.FirstOrDefault(u => u.id == 2)?.name;

            var model = new ChatViewModel
            {
                CurrentUserId = 1,
                ChatPartnerId = 2,
                ChatPartnerName = chatPartnerName ?? "Unknown",
                Messages = messages
            };

            return View(model);
        }

        public IActionResult Index()
        {
            var users = _context.Users.ToList();
            // Exclude the current user from the list, assuming you have a way to identify them (e.g., via authentication)
            return View(users);
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(int senderId, int receiverId, string message)
        {
            _chatControl.SendMessage(senderId, receiverId, message);
            // Simulate async operation
            await Task.Delay(10);
            DateTime now = DateTime.Now;
            return Json(new { success = true, message, senderId, receiverId, createdAt = now.ToString("o") });
        }

        // Assuming you have this method or similar for fetching messages
        public IActionResult RetrieveMessages(int userId, int chatPartnerId)
        {
            var messages = _chatControl.RetrieveMessages(userId, chatPartnerId);
            return Json(messages);
        }

    }
}