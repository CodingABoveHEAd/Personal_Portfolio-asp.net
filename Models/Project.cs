using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Personal_Portfolio2.Models
{
    public class Project
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }

        public string Tags { get; set; }

        [NotMapped]
        public List<string> TagsList
        {
            get
            {
                return string.IsNullOrEmpty(Tags) ? new List<string>() : Tags.Split(',').ToList();
            }
        }
    }
}
