namespace BCSDirectory.WebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialCreation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Hobbies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LastName = c.String(),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        PhoneNumber = c.String(),
                        Gender = c.Int(nullable: false),
                        Birthdate = c.DateTime(nullable: false),
                        Address = c.String(),
                        CivilStatus = c.Int(nullable: false),
                        UserType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserHobbies",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        Hobby_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Hobby_Id })
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.Hobbies", t => t.Hobby_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.Hobby_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserHobbies", "Hobby_Id", "dbo.Hobbies");
            DropForeignKey("dbo.UserHobbies", "User_Id", "dbo.Users");
            DropIndex("dbo.UserHobbies", new[] { "Hobby_Id" });
            DropIndex("dbo.UserHobbies", new[] { "User_Id" });
            DropTable("dbo.UserHobbies");
            DropTable("dbo.Users");
            DropTable("dbo.Hobbies");
        }
    }
}
