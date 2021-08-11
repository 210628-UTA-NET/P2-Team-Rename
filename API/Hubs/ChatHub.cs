using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;
using BL;

using Entities.Database;
using System.Collections.Generic;

namespace API.Hubs {
    public class ChatHub : Hub {
        private MessageManager _messageManager;

        public ChatHub(MessageManager messageManager) {
            _messageManager = messageManager;
        }

        public async Task PrivateChat(Message message) {
            string chatId = GenerateChatId(message.SenderId, message.ReceiverId);
            await Clients.Group(chatId).SendAsync("MessageReceived", message);
            await _messageManager.AddMessage(message);
        }

        public async Task JoinPrivateChat(string targetUserId) {
            var userId = Context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            string chatId = GenerateChatId(userId, targetUserId);
            await Groups.AddToGroupAsync(Context.ConnectionId, chatId);
            //Load all previous messages
            IList<Message> previousMessages = await _messageManager.GetPrivateMessages(userId, targetUserId);
            foreach (Message message in previousMessages) {
                await Clients.Group(chatId).SendAsync("MessageReceived", message);
            }
        }

        public async Task LeavePrivateChat(string targetUserId) {
            var userId = Context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            string chatId = GenerateChatId(userId, targetUserId);
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, chatId);
        }

        public async Task TestPrivateChat(Message message) {
            //var senderId = Context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            string chatId = GenerateChatId(message.SenderId, message.ReceiverId);
            await Clients.Group(chatId).SendAsync("MessageReceived", message);
        }

        public async Task JoinPrivateChatTest(string userId, string targetUserId) {
            //var userId = Context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            string chatId = GenerateChatId(userId, targetUserId);
            await Groups.AddToGroupAsync(Context.ConnectionId, chatId);
            await Clients.Group(chatId).SendAsync("Send", $"{Context.ConnectionId} has joined the chat.");
        }

        public async Task LeavePrivateChatTest(string userId, string targetUserId) {
            //var userId = Context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            //if (userId == null) return;
            string chatId = GenerateChatId(userId, targetUserId);
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, chatId);
            await Clients.Group(chatId).SendAsync("Send", $"{Context.ConnectionId} has left the chat.");
        }

        public static string GenerateChatId(string userIdA, string userIdB) {
            return (string.Compare(userIdA, userIdB) < 0)
                ? ($"{userIdA}+{userIdB}")
                : ($"{userIdB}+{userIdA}");
        }
    }
}