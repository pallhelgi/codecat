namespace CodeCat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DocumentModel1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DocumentModels", "ProjectID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DocumentModels", "ProjectID");
        }
    }
}
