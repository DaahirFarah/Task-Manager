namespace TaskM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class namechange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tasks", "TaskName", c => c.String(nullable: false));
            DropColumn("dbo.Tasks", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tasks", "Name", c => c.String(nullable: false));
            DropColumn("dbo.Tasks", "TaskName");
        }
    }
}
