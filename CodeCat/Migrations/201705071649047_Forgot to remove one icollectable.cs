namespace CodeCat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Forgottoremoveoneicollectable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProjectModels", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.ProjectModels", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.ProjectModels", "ApplicationUser_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProjectModels", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.ProjectModels", "ApplicationUser_Id");
            AddForeignKey("dbo.ProjectModels", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
