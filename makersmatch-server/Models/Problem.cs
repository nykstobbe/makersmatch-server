using System.ComponentModel.DataAnnotations;

namespace makersmatch_server.Models
{
    public class Problem
    {
        public int? Id { get; set; }
        public string? UserId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public List<Image> Images { get; set; } = new List<Image>();
        public bool IsSolved { get; set; } = false;
    }
}
