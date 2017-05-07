namespace CodeCat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ASpNetUserAdd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplicationUserProjectModels",
                c => new
                    {
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                        ProjectModel_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicationUser_Id, t.ProjectModel_ID })
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .ForeignKey("dbo.ProjectModels", t => t.ProjectModel_ID, cascadeDelete: true)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.ProjectModel_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApplicationUserProjectModels", "ProjectModel_ID", "dbo.ProjectModels");
            DropForeignKey("dbo.ApplicationUserProjectModels", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.ApplicationUserProjectModels", new[] { "ProjectModel_ID" });
            DropIndex("dbo.ApplicationUserProjectModels", new[] { "ApplicationUser_Id" });
            DropTable("dbo.ApplicationUserProjectModels");
        }
    }
}
