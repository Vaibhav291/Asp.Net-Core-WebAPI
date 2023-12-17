using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Code_to_Build.Model
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Content { get; set; }
        public int Like { get; set; }
        public string? Comments { get; set; }
        [Required]
        public string? ImageUrl { get; set; }
        public DateTime? CreateOn { get; set; }

        [ForeignKey("UserId")]
        public virtual User Users { get; set; }
    }
}
