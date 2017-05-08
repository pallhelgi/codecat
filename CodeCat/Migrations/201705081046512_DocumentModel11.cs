namespace CodeCat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DocumentModel11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DocumentModels", "type", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DocumentModels", "type");
        }
    }
}
