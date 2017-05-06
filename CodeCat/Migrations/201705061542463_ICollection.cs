namespace CodeCat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ICollection : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProjectModelDocumentModels",
                c => new
                    {
                        ProjectModel_ID = c.Int(nullable: false),
                        DocumentModel_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProjectModel_ID, t.DocumentModel_ID })
                .ForeignKey("dbo.ProjectModels", t => t.ProjectModel_ID, cascadeDelete: true)
                .ForeignKey("dbo.DocumentModels", t => t.DocumentModel_ID, cascadeDelete: true)
                .Index(t => t.ProjectModel_ID)
                .Index(t => t.DocumentModel_ID);
            
            CreateTable(
                "dbo.UserModelProjectModels",
                c => new
                    {
                        UserModel_ID = c.Int(nullable: false),
                        ProjectModel_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserModel_ID, t.ProjectModel_ID })
                .ForeignKey("dbo.UserModels", t => t.UserModel_ID, cascadeDelete: true)
                .ForeignKey("dbo.ProjectModels", t => t.ProjectModel_ID, cascadeDelete: true)
                .Index(t => t.UserModel_ID)
                .Index(t => t.ProjectModel_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserModelProjectModels", "ProjectModel_ID", "dbo.ProjectModels");
            DropForeignKey("dbo.UserModelProjectModels", "UserModel_ID", "dbo.UserModels");
            DropForeignKey("dbo.ProjectModelDocumentModels", "DocumentModel_ID", "dbo.DocumentModels");
            DropForeignKey("dbo.ProjectModelDocumentModels", "ProjectModel_ID", "dbo.ProjectModels");
            DropIndex("dbo.UserModelProjectModels", new[] { "ProjectModel_ID" });
            DropIndex("dbo.UserModelProjectModels", new[] { "UserModel_ID" });
            DropIndex("dbo.ProjectModelDocumentModels", new[] { "DocumentModel_ID" });
            DropIndex("dbo.ProjectModelDocumentModels", new[] { "ProjectModel_ID" });
            DropTable("dbo.UserModelProjectModels");
            DropTable("dbo.ProjectModelDocumentModels");
        }
    }
}
