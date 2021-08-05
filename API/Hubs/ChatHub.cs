using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

using DL.Entities;

namespace API.Hubs {
    public class ChatHub : Hub {
        public async Task GroupChat(ChatMessage message) {
            await Clients.Group(GenerateChatId(message.SenderId, message.ReceiverId)).SendAsync("MessageRecieved", message);
        }

        public async Task AddToGroup(string chatId) {
            await Groups.AddToGroupAsync(Context.ConnectionId, chatId);
            await Clients.Group(chatId).SendAsync("Send", $"{Context.ConnectionId} has joined the chat.");
        }

        public async Task RemoveFromGroup(string chatId) {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, chatId);
            await Clients.Group(chatId).SendAsync("Send", $"{Context.ConnectionId} has left the chat.");
        }

        public static string GenerateChatId(string userIdA, string userIdB) {
            return (string.Compare(userIdA, userIdB) < 0)
                ? ($"{userIdA}-{userIdB}")
                : ($"{userIdB}-{userIdA}");
        }
    }
}