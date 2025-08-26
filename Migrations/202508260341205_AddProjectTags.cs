namespace Personal_Portfolio2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProjectTags : DbMigration
    {
        public override void Up()
        {
           // AddColumn("dbo.Projects", "Tags", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Projects", "Tags");
        }
    }
}
