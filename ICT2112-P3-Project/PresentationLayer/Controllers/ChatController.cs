using Microsoft.AspNetCore.Mvc;
using DomainLayer.Control;
using DomainLayer.Interface;
using DataSourceLayer.Data; // Assuming your DataContext is here
using PresentationLayer.ViewModel; // Update this namespace based on your project structure
using System.Linq;
using DomainLayer.Entity;
using DomainLayer.Factory;
using System.Text.Json;

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

        public IActionResult Chat()
        {
            int testUserId = 2; // Simulate logged-in user with ID 1
            int testChatPartnerId = 1; // Simulate chat partner with ID 2

            // Retrieve messages between the test user and test chat partner
            var messages = _chatControl.RetrieveMessages(testUserId, testChatPartnerId);

            // Get the test chat partner's name
            var chatPartnerName = _context.Users.FirstOrDefault(u => u.id == testChatPartnerId)?.name;

            // Prepare the view model with test data
            var model = new ChatViewModel
            {
                CurrentUserId = testUserId,
                ChatPartnerId = testChatPartnerId,
                ChatPartnerName = chatPartnerName ?? "Unknown",
                Messages = messages
            };

            // Render the Chat view with the test data
            return View("Chat", model); // Make sure you pass the "Chat" view if your test method has a different name
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

        [HttpPost]
        public IActionResult MarkMessagesAsRead([FromForm] List<int> messageIds, [FromForm] int currentUserId)
        {
            if (messageIds == null || !messageIds.Any())
            {
                return Json(new { success = false, message = "No message IDs provided." });
            }

            foreach (var messageId in messageIds)
            {
                _chatControl.MarkMessageAsRead(messageId, currentUserId);
            }

            return Json(new { success = true });
        }

    }
}