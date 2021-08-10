using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using DL;
using Entities.Database;

namespace BL {
    public class MessageManager {
        private readonly IDatabase<Message> _messageDB;
        private readonly IDatabase<FollowRequest> _followRequestDB;

        public MessageManager(IDatabase<Message> messageDB, IDatabase<FollowRequest> followRequestDB) {
            _messageDB = messageDB;
            _followRequestDB = followRequestDB;
        }

        public async Task<IList<Message>> GetPrivateMessages(string userAId, string userBId) {
            return await _messageDB.Query(new() {
                Conditions = new List<Func<Message, bool>>{
                    m => (m.SenderId == userAId && m.ReceiverId == userBId)
                        || (m.SenderId == userBId && m.ReceiverId ==userAId)
                },
                OrderBy  = "Timestamp"
            });
        }

        public async Task<Message> AddMessage(Message message) {
            return await _messageDB.Create(message);
        }

        public async Task<bool> DeleteMessage(string messageId) {
            try {
                Message targetMessage = await _messageDB.FindSingle(new() {
                    Conditions = new List<Func<Message, bool>> {
                        m => m.Id == messageId
                    }
                });
                _messageDB.Delete(targetMessage);
                return true;
            } catch (Exception ) {
                return false;
            }
        }

        public async Task<FollowRequest> AddFollowRequest(FollowRequest request) {
            return await _followRequestDB.Create(request);
        }

        public async Task<IList<FollowRequest>> GetTutorFollowRequests(string userId) {
            return await _followRequestDB.Query(new() {
                Conditions = new List<Func<FollowRequest, bool>>{
                    m => m.ReceiverId == userId
                },
                OrderBy  = "Timestamp"
            });
        }

        public async Task<bool> DeleteFollowRequest(string messageId) {
            try {
                FollowRequest targetMessage = await _followRequestDB.FindSingle(new() {
                    Conditions = new List<Func<FollowRequest, bool>> {
                        m => m.Id == messageId
                    }
                });
                _followRequestDB.Delete(targetMessage);
                return true;
            } catch (Exception ) {
                return false;
            }
        }
    }
}