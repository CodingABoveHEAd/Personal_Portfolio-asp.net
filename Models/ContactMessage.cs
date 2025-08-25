using System;

namespace Personal_Portfolio2.Models
{
    public class ContactMessage
    {
        public int Id { get; set; }  // Primary key
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public DateTime DateSent { get; set; } = DateTime.Now;
    }
}
