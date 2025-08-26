using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Personal_Portfolio2.Models  // <-- Add this namespace
{
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }

        // Existing column in DB
        public string Tags { get; set; }

        // Not mapped property for frontend
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
