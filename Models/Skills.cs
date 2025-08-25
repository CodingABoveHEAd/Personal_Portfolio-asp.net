using System.ComponentModel.DataAnnotations;

namespace Personal_Portfolio2.Models
.Models
{
    public class Skill
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int Level { get; set; } // 1–10 scale
    }
}
