namespace ProjectManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TaskId = c.Int(nullable: false),
                        Title = c.String(),
                        Content = c.String(),
                        CreatorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        SecondName = c.String(),
                        LastName = c.String(),
                        ManagerId = c.Int(nullable: false),
                        PositionId = c.Int(nullable: false),
                        TeamId = c.Int(nullable: false),
                        Phone = c.String(),
                        Adress = c.String(),
                        DateofBirth = c.DateTime(nullable: false),
                        Password = c.String(),
                        Email = c.String(),
                        AdminRole = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Salary = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Project_Report",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProjectId = c.Int(nullable: false),
                        Title = c.String(),
                        Content = c.String(),
                        CreatorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        TeamId = c.Int(nullable: false),
                        Finished = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        AssignetId = c.Int(nullable: false),
                        ProjectId = c.Int(nullable: false),
                        LogWork = c.Double(nullable: false),
                        Status = c.String(),
                        PercentageDone = c.Int(nullable: false),
                        CreatorId_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.CreatorId_Id)
                .Index(t => t.CreatorId_Id);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DepartmentId = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "CreatorId_Id", "dbo.Employees");
            DropIndex("dbo.Tasks", new[] { "CreatorId_Id" });
            DropTable("dbo.Teams");
            DropTable("dbo.Tasks");
            DropTable("dbo.Projects");
            DropTable("dbo.Project_Report");
            DropTable("dbo.Positions");
            DropTable("dbo.Employees");
            DropTable("dbo.Departments");
            DropTable("dbo.Comments");
        }
    }
}
