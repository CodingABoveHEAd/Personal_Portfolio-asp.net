using System.ComponentModel.DataAnnotations;

namespace Personal_Portfolio2.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public string Url { get; set; }  // GitHub link or live demo
    }
}
