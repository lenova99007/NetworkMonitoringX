using Microsoft.AspNetCore.SignalR;
using NetworkMonitoring.Shared.Data;
using NetworkMonitoring.Shared.Models;
using System.Threading.Tasks;

namespace NetworkMonitoring.Web.Hubs
{
    public class ChatHub : Hub
    {
        private readonly AppDbContext _db;
        public ChatHub(AppDbContext db) { _db = db; }

        public async Task SendMessage(ChatMessageDto msg)
        {
            // Convert string IDs to int? for database
            int? senderId = int.TryParse(msg.SenderId, out int sId) ? sId : null;
            int? receiverId = int.TryParse(msg.ReceiverId, out int rId) ? rId : null;

            var chat = new ChatMessage
            {
                SenderId = senderId,
                ReceiverId = receiverId,
                MessageText = msg.Message,
                CreatedAt = msg.SentAt
            };

            _db.ChatMessages.Add(chat);
            await _db.SaveChangesAsync();
            msg.Id = chat.ChatMessageId;

            await Clients.All.SendAsync("ReceiveMessage", msg);
        }

        public async Task BroadcastLog(LogAlertDto log)
        {
            await Clients.All.SendAsync("ReceiveLog", log);
        }
    }
}