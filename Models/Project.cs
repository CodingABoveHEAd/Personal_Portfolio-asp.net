using System;

namespace YourProjectNamespace.Models
{
    public class Project
    {
        public int Id { get; set; }  // Primary key
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }  // Link to project or GitHub
        public string ImageUrl { get; set; }  // Optional image path
    }
}
