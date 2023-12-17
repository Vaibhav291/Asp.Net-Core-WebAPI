using System.ComponentModel.DataAnnotations;

namespace Code_to_Build.Model
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
