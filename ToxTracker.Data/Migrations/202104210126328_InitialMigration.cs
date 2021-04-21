namespace ToxTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Analyte",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StandardId = c.Int(nullable: false),
                        StockId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Standard", t => t.StandardId, cascadeDelete: true)
                .ForeignKey("dbo.Stock", t => t.StockId, cascadeDelete: true)
                .Index(t => t.StandardId)
                .Index(t => t.StockId);
            
            CreateTable(
                "dbo.QCType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Level = c.String(nullable: false),
                        Concentration = c.Double(nullable: false),
                        Unit = c.String(nullable: false),
                        AnalyteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Analyte", t => t.AnalyteId, cascadeDelete: true)
                .Index(t => t.AnalyteId);
            
            CreateTable(
                "dbo.ControlChart",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QuantValue = c.Double(nullable: false),
                        RunDate = c.DateTimeOffset(nullable: false, precision: 7),
                        BatchName = c.String(nullable: false),
                        QCId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.QCType", t => t.QCId, cascadeDelete: true)
                .Index(t => t.QCId);
            
            CreateTable(
                "dbo.Standard",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Concentration = c.Double(nullable: false),
                        Unit = c.String(),
                        LotNumber = c.String(nullable: false),
                        CatNumber = c.String(nullable: false),
                        IsDeuterated = c.Boolean(nullable: false),
                        OpenDate = c.DateTimeOffset(nullable: false, precision: 7),
                        ExpireDate = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Stock",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Assay = c.String(nullable: false),
                        LotNumber = c.String(nullable: false),
                        Type = c.String(nullable: false),
                        IsApproved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Analyte", "StockId", "dbo.Stock");
            DropForeignKey("dbo.Analyte", "StandardId", "dbo.Standard");
            DropForeignKey("dbo.ControlChart", "QCId", "dbo.QCType");
            DropForeignKey("dbo.QCType", "AnalyteId", "dbo.Analyte");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.ControlChart", new[] { "QCId" });
            DropIndex("dbo.QCType", new[] { "AnalyteId" });
            DropIndex("dbo.Analyte", new[] { "StockId" });
            DropIndex("dbo.Analyte", new[] { "StandardId" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Stock");
            DropTable("dbo.Standard");
            DropTable("dbo.ControlChart");
            DropTable("dbo.QCType");
            DropTable("dbo.Analyte");
        }
    }
}
