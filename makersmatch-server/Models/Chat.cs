namespace makersmatch_server.Models
{
    public class Chat
    {
        public int Id { get; set; }
        public SimpleUser User1 { get; set; }
        public SimpleUser User2 { get; set; }
        public ICollection<ChatMessage> ChatMessages { get; set;}
    }
}
