namespace DataAcsess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BaseTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Message = c.String(),
                        Date = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Hashes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Path = c.String(),
                        Subject_id = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Logins",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Password = c.String(),
                        isRegisted = c.Boolean(nullable: false),
                        Role = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OrderNumber = c.String(),
                        SubjectID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Date = c.String(),
                        Status = c.Int(nullable: false),
                        Total = c.Double(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Title = c.String(),
                        Description = c.String(),
                        Price = c.Double(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Date = c.String(),
                        Image = c.String(),
                        Basetype = c.Int(nullable: false),
                        Type = c.Int(nullable: false),
                        Front = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TypeSubjects",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BaseTypeID = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SecondName = c.String(),
                        City = c.String(),
                        Adress = c.String(),
                        Telephone = c.String(),
                        Image = c.String(),
                        LoginID = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.TypeSubjects");
            DropTable("dbo.Products");
            DropTable("dbo.Orders");
            DropTable("dbo.Logins");
            DropTable("dbo.Images");
            DropTable("dbo.Hashes");
            DropTable("dbo.Contacts");
            DropTable("dbo.BaseTypes");
        }
    }
}
