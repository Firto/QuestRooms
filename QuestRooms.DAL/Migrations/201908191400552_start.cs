namespace QuestRooms.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class start : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        HouseNumber = c.String(),
                        City_ID = c.Int(),
                        Country_ID = c.Int(),
                        Street_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Cities", t => t.City_ID)
                .ForeignKey("dbo.Countries", t => t.Country_ID)
                .ForeignKey("dbo.Streets", t => t.Street_ID)
                .Index(t => t.City_ID)
                .Index(t => t.Country_ID)
                .Index(t => t.Street_ID);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Streets",
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
                        Name = c.String(),
                        QuestRoom_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.QuestRooms", t => t.QuestRoom_ID)
                .Index(t => t.QuestRoom_ID);
            
            CreateTable(
                "dbo.QuestRooms",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        TimeTravel = c.Time(nullable: false, precision: 7),
                        MobileNumber = c.String(),
                        Email = c.String(),
                        Rating = c.Byte(nullable: false),
                        FearLevel = c.Byte(nullable: false),
                        DifficultLevel = c.Byte(nullable: false),
                        Logo = c.String(),
                        Address_ID = c.Int(),
                        Company_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Addresses", t => t.Address_ID)
                .ForeignKey("dbo.Companies", t => t.Company_ID)
                .Index(t => t.Address_ID)
                .Index(t => t.Company_ID);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Images", "QuestRoom_ID", "dbo.QuestRooms");
            DropForeignKey("dbo.QuestRooms", "Company_ID", "dbo.Companies");
            DropForeignKey("dbo.QuestRooms", "Address_ID", "dbo.Addresses");
            DropForeignKey("dbo.Addresses", "Street_ID", "dbo.Streets");
            DropForeignKey("dbo.Addresses", "Country_ID", "dbo.Countries");
            DropForeignKey("dbo.Addresses", "City_ID", "dbo.Cities");
            DropIndex("dbo.QuestRooms", new[] { "Company_ID" });
            DropIndex("dbo.QuestRooms", new[] { "Address_ID" });
            DropIndex("dbo.Images", new[] { "QuestRoom_ID" });
            DropIndex("dbo.Addresses", new[] { "Street_ID" });
            DropIndex("dbo.Addresses", new[] { "Country_ID" });
            DropIndex("dbo.Addresses", new[] { "City_ID" });
            DropTable("dbo.Companies");
            DropTable("dbo.QuestRooms");
            DropTable("dbo.Images");
            DropTable("dbo.Streets");
            DropTable("dbo.Countries");
            DropTable("dbo.Cities");
            DropTable("dbo.Addresses");
        }
    }
}
