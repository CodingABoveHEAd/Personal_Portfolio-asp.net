using System.ComponentModel.DataAnnotations;

namespace Personal_Portfolio2.Models
{
    public class Education
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Degree { get; set; }

        [Required]
        public string Institute { get; set; }

        public string Year { get; set; }
    }
}
