namespace CodeCat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserModelErasedEmailError : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.UserModels", "emailError");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserModels", "emailError", c => c.String());
        }
    }
}
