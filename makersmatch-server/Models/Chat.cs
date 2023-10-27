namespace makersmatch_server.Models
{
    public class Chat
    {
        public int Id { get; set; }
        public string User1ID { get; set; }
        public string User2ID { get; set; }
        public ICollection<ChatMessage> ChatMessages { get; set;} = new List<ChatMessage>();
    }
}
