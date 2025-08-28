
using System.Data.Entity;

namespace Personal_Portfolio2.Models
{
    public class PortfolioContext : DbContext
    {
        public PortfolioContext() : base("PortfolioDb") { }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<ContactMessage> ContactMessages { get; set; }
    }
}
