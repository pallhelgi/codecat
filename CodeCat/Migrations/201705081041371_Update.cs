namespace CodeCat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.DocumentModels", "type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DocumentModels", "type", c => c.Int(nullable: false));
        }
    }
}
