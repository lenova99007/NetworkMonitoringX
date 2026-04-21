using System;

namespace NetworkMonitoring.Shared.Models
{
    public class ChatMessage
    {
        public int ChatMessageId { get; set; }  // Changed from Id
        public int? SenderId { get; set; }      // Changed from string
        public int? ReceiverId { get; set; }    // Changed from string
        public string? MessageText { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}