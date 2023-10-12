namespace makersmatch_server.Models
{
    public class Problem
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Image> Images { get; set; }
        public bool IsSolved { get; set; }
    }
}
