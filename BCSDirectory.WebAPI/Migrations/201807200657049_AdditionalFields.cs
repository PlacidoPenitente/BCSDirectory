namespace BCSDirectory.WebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdditionalFields : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Department_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.Department_Id)
                .Index(t => t.Department_Id);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Users", "Username", c => c.String());
            AddColumn("dbo.Users", "PasswordHint", c => c.String());
            AddColumn("dbo.Users", "Position_Id", c => c.Int());
            CreateIndex("dbo.Users", "Position_Id");
            AddForeignKey("dbo.Users", "Position_Id", "dbo.Positions", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Position_Id", "dbo.Positions");
            DropForeignKey("dbo.Positions", "Department_Id", "dbo.Departments");
            DropIndex("dbo.Positions", new[] { "Department_Id" });
            DropIndex("dbo.Users", new[] { "Position_Id" });
            DropColumn("dbo.Users", "Position_Id");
            DropColumn("dbo.Users", "PasswordHint");
            DropColumn("dbo.Users", "Username");
            DropTable("dbo.Departments");
            DropTable("dbo.Positions");
        }
    }
}
