namespace CodeCat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProjectModel1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProjectModels", "creatorUserID", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProjectModels", "creatorUserID", c => c.Int(nullable: false));
        }
    }
}
