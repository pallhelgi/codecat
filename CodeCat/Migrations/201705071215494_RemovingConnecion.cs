namespace CodeCat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovingConnecion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProjectModels", "UserModel_ID", c => c.Int());
            CreateIndex("dbo.ProjectModels", "UserModel_ID");
            AddForeignKey("dbo.ProjectModels", "UserModel_ID", "dbo.UserModels", "ID");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserModelProjectModels",
                c => new
                    {
                        UserModel_ID = c.Int(nullable: false),
                        ProjectModel_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserModel_ID, t.ProjectModel_ID });
            
            DropForeignKey("dbo.ProjectModels", "UserModel_ID", "dbo.UserModels");
            DropIndex("dbo.ProjectModels", new[] { "UserModel_ID" });
            DropColumn("dbo.ProjectModels", "UserModel_ID");
            CreateIndex("dbo.UserModelProjectModels", "ProjectModel_ID");
            CreateIndex("dbo.UserModelProjectModels", "UserModel_ID");
            AddForeignKey("dbo.UserModelProjectModels", "ProjectModel_ID", "dbo.ProjectModels", "ID", cascadeDelete: true);
            AddForeignKey("dbo.UserModelProjectModels", "UserModel_ID", "dbo.UserModels", "ID", cascadeDelete: true);
        }
    }
}
