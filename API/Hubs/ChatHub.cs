using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;

using DL.Entities;

namespace API.Hubs {
    public class ChatHub : Hub {
        public async Task PrivateChat(ChatMessage message) {
            //var senderId = Context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            string chatId = GenerateChatId(message.SenderId, message.ReceiverId);
            await Clients.Group(chatId).SendAsync("MessageReceived", message);
        }

        public async Task JoinPrivateChat(string userId, string targetUserId) {
            //var userId = Context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            string chatId = GenerateChatId(userId, targetUserId);
            await Groups.AddToGroupAsync(Context.ConnectionId, chatId);
            await Clients.Group(chatId).SendAsync("Send", $"{Context.ConnectionId} has joined the chat.");
        }

        public async Task LeavePrivateChat(string userId, string targetUserId) {
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