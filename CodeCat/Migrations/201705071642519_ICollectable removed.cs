namespace CodeCat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ICollectableremoved : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DocumentModels", "projects_ID", "dbo.ProjectModels");
            DropForeignKey("dbo.ApplicationUserProjectModels", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ApplicationUserProjectModels", "ProjectModel_ID", "dbo.ProjectModels");
            DropForeignKey("dbo.ProjectModels", "UserModel_ID", "dbo.UserModels");
            DropIndex("dbo.DocumentModels", new[] { "projects_ID" });
            DropIndex("dbo.ProjectModels", new[] { "UserModel_ID" });
            DropIndex("dbo.ApplicationUserProjectModels", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.ApplicationUserProjectModels", new[] { "ProjectModel_ID" });
            AddColumn("dbo.ProjectModels", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.ProjectModels", "ApplicationUser_Id");
            AddForeignKey("dbo.ProjectModels", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.DocumentModels", "projects_ID");
            DropColumn("dbo.ProjectModels", "UserModel_ID");
            DropTable("dbo.ApplicationUserProjectModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ApplicationUserProjectModels",
                c => new
                    {
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                        ProjectModel_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicationUser_Id, t.ProjectModel_ID });
            
            AddColumn("dbo.ProjectModels", "UserModel_ID", c => c.Int());
            AddColumn("dbo.DocumentModels", "projects_ID", c => c.Int());
            DropForeignKey("dbo.ProjectModels", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.ProjectModels", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.ProjectModels", "ApplicationUser_Id");
            CreateIndex("dbo.ApplicationUserProjectModels", "ProjectModel_ID");
            CreateIndex("dbo.ApplicationUserProjectModels", "ApplicationUser_Id");
            CreateIndex("dbo.ProjectModels", "UserModel_ID");
            CreateIndex("dbo.DocumentModels", "projects_ID");
            AddForeignKey("dbo.ProjectModels", "UserModel_ID", "dbo.UserModels", "ID");
            AddForeignKey("dbo.ApplicationUserProjectModels", "ProjectModel_ID", "dbo.ProjectModels", "ID", cascadeDelete: true);
            AddForeignKey("dbo.ApplicationUserProjectModels", "ApplicationUser_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.DocumentModels", "projects_ID", "dbo.ProjectModels", "ID");
        }
    }
}
