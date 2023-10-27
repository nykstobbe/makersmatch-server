using System.ComponentModel.DataAnnotations.Schema;

namespace makersmatch_server.Models
{
    public class ChatMessage
    {
        public int Id { get; set; }
        public Chat Chat { get; set; }
        public string SenderID { get; set; }
        public string Message { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedDate { get; set; }
    }
}
