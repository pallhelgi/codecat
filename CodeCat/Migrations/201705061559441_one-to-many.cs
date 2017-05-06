namespace CodeCat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class onetomany : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProjectModelDocumentModels", "ProjectModel_ID", "dbo.ProjectModels");
            DropForeignKey("dbo.ProjectModelDocumentModels", "DocumentModel_ID", "dbo.DocumentModels");
            DropIndex("dbo.ProjectModelDocumentModels", new[] { "ProjectModel_ID" });
            DropIndex("dbo.ProjectModelDocumentModels", new[] { "DocumentModel_ID" });
            AddColumn("dbo.DocumentModels", "projects_ID", c => c.Int());
            CreateIndex("dbo.DocumentModels", "projects_ID");
            AddForeignKey("dbo.DocumentModels", "projects_ID", "dbo.ProjectModels", "ID");
            DropTable("dbo.ProjectModelDocumentModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ProjectModelDocumentModels",
                c => new
                    {
                        ProjectModel_ID = c.Int(nullable: false),
                        DocumentModel_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProjectModel_ID, t.DocumentModel_ID });
            
            DropForeignKey("dbo.DocumentModels", "projects_ID", "dbo.ProjectModels");
            DropIndex("dbo.DocumentModels", new[] { "projects_ID" });
            DropColumn("dbo.DocumentModels", "projects_ID");
            CreateIndex("dbo.ProjectModelDocumentModels", "DocumentModel_ID");
            CreateIndex("dbo.ProjectModelDocumentModels", "ProjectModel_ID");
            AddForeignKey("dbo.ProjectModelDocumentModels", "DocumentModel_ID", "dbo.DocumentModels", "ID", cascadeDelete: true);
            AddForeignKey("dbo.ProjectModelDocumentModels", "ProjectModel_ID", "dbo.ProjectModels", "ID", cascadeDelete: true);
        }
    }
}
