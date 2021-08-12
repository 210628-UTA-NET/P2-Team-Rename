using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;
using BL;

using Entities.Database;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Authorization;

namespace API.Hubs {

    [Authorize]
    public class ChatHub : Hub {
        private MessageManager _messageManager;

        public ChatHub(MessageManager messageManager) {
            _messageManager = messageManager;
        }

        public async Task PrivateChat(Message message) {
            string chatId = GenerateChatId(message.SenderId, message.ReceiverId);
            await Clients.Group(chatId).SendAsync("Message", message);
            await _messageManager.AddMessage(message);
        }

        public async Task JoinPrivateChat(string targetUserId) {
            var userId = Context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            string chatId = GenerateChatId(userId, targetUserId);
            await Groups.AddToGroupAsync(Context.ConnectionId, chatId);
            //Load all previous messages
            IList<Message> previousMessages = await _messageManager.GetPrivateMessages(userId, targetUserId);
            foreach (Message message in previousMessages) {
                message.TimeSent = message.TimeSent.ToLocalTime();
                await Clients.User(userId).SendAsync("Message", message);
            }
        }

        public async Task LeavePrivateChat(string targetUserId) {
            var userId = Context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            string chatId = GenerateChatId(userId, targetUserId);
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, chatId);
        }

        public static string GenerateChatId(string userIdA, string userIdB) {
            return (string.Compare(userIdA, userIdB) < 0)
                ? ($"{userIdA}+{userIdB}")
                : ($"{userIdB}+{userIdA}");
        }
    }
}