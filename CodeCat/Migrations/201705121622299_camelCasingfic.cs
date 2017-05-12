namespace CodeCat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class camelCasingfic : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ProjectModels", "isActive");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProjectModels", "isActive", c => c.Boolean(nullable: false));
        }
    }
}
