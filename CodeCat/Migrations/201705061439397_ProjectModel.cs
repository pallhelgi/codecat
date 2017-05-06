namespace CodeCat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProjectModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProjectModels", "name", c => c.String(nullable: false, maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProjectModels", "name", c => c.String(nullable: false));
        }
    }
}
