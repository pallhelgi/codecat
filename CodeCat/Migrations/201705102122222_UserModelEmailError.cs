namespace CodeCat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserModelEmailError : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserModels", "emailError", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserModels", "emailError");
        }
    }
}
