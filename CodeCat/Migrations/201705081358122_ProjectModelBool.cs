namespace CodeCat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProjectModelBool : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProjectModels", "isActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProjectModels", "isActive");
        }
    }
}
