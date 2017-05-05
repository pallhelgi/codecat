namespace CodeCat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DocumentModel : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.DocumendModels", newName: "DocumentModels");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.DocumentModels", newName: "DocumendModels");
        }
    }
}
