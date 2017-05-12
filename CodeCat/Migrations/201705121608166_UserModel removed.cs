namespace CodeCat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserModelremoved : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.UserModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        username = c.String(nullable: false),
                        password = c.String(nullable: false),
                        confirmPassword = c.String(),
                        email = c.String(nullable: false),
                        fullName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
    }
}
