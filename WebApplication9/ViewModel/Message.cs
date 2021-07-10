using System;

namespace WebApplication9.ViewModel
{
    public class Message
    {
        public Guid MessageID { get; set; }
        public string FromUserID { get; set; }
        public string ToUserID { get; set; }
        public string MessageText { get; set; }
        public DateTime MessageDateTime { get; set; } = DateTime.UtcNow;
    }
}
