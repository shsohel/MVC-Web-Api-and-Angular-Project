namespace JobMvcApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MVCdA : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        AddressID = c.Int(nullable: false, identity: true),
                        PresentAddress = c.String(maxLength: 50),
                        PermanentAddress = c.String(maxLength: 50),
                        PersonalDetailID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AddressID)
                .ForeignKey("dbo.PersonalDetails", t => t.PersonalDetailID, cascadeDelete: true)
                .Index(t => t.PersonalDetailID);
            
            CreateTable(
                "dbo.PersonalDetails",
                c => new
                    {
                        PersonalDetailID = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        UserName = c.String(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        FatherName = c.String(),
                        MotherName = c.String(),
                        NationalID = c.String(),
                        CellPhone = c.String(),
                        Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.PersonalDetailID);
            
            CreateTable(
                "dbo.ApplyJobs",
                c => new
                    {
                        ApplyJobID = c.Int(nullable: false, identity: true),
                        JobListID = c.Int(nullable: false),
                        PersonalDetailID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ApplyJobID)
                .ForeignKey("dbo.JobLists", t => t.JobListID, cascadeDelete: true)
                .ForeignKey("dbo.PersonalDetails", t => t.PersonalDetailID, cascadeDelete: true)
                .Index(t => t.JobListID)
                .Index(t => t.PersonalDetailID);
            
            CreateTable(
                "dbo.JobLists",
                c => new
                    {
                        JobListID = c.Int(nullable: false, identity: true),
                        EmployerID = c.Int(nullable: false),
                        Position = c.String(),
                        NumberofPost = c.Int(nullable: false),
                        SalaryScale = c.String(),
                        AgeLimit = c.String(),
                        EducationRequirement = c.String(),
                        LastDateofApplication = c.DateTime(nullable: false),
                        IsApprove = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.JobListID)
                .ForeignKey("dbo.Employers", t => t.EmployerID, cascadeDelete: true)
                .Index(t => t.EmployerID);
            
            CreateTable(
                "dbo.Employers",
                c => new
                    {
                        EmployerID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        UserId = c.String(),
                        CompanyName = c.String(),
                        Catageory = c.String(),
                        BusinessDescription = c.String(),
                        WebsiteUrl = c.String(),
                        PhoneNumber = c.String(),
                        TelePhone = c.String(),
                        Fax = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.EmployerID);
            
            CreateTable(
                "dbo.CompanyAddresses",
                c => new
                    {
                        CompanyAddressID = c.Int(nullable: false, identity: true),
                        Country = c.String(),
                        District = c.String(),
                        Thana = c.String(),
                        AddressDetails = c.String(),
                        EmployerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CompanyAddressID)
                .ForeignKey("dbo.Employers", t => t.EmployerID, cascadeDelete: true)
                .Index(t => t.EmployerID);
            
            CreateTable(
                "dbo.Educations",
                c => new
                    {
                        EducationID = c.Int(nullable: false, identity: true),
                        LevelOfEducation = c.String(),
                        CGPA = c.String(),
                        Scale = c.String(),
                        DegreeTitle = c.String(),
                        Group = c.String(),
                        Institute = c.String(),
                        PassingYear = c.String(),
                        Duration = c.String(),
                        Achievement = c.String(),
                        PersonalDetailID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EducationID)
                .ForeignKey("dbo.PersonalDetails", t => t.PersonalDetailID, cascadeDelete: true)
                .Index(t => t.PersonalDetailID);
            
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        SkillID = c.Int(nullable: false, identity: true),
                        SkillName = c.String(),
                        PersonalDetailID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SkillID)
                .ForeignKey("dbo.PersonalDetails", t => t.PersonalDetailID, cascadeDelete: true)
                .Index(t => t.PersonalDetailID);
            
            CreateTable(
                "dbo.Trainings",
                c => new
                    {
                        TrainingID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Topics = c.String(),
                        Institute = c.String(),
                        Location = c.String(),
                        Country = c.String(),
                        TrainingYear = c.String(),
                        Duration = c.String(),
                        PersonalDetailID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TrainingID)
                .ForeignKey("dbo.PersonalDetails", t => t.PersonalDetailID, cascadeDelete: true)
                .Index(t => t.PersonalDetailID);
            
            CreateTable(
                "dbo.Experiences",
                c => new
                    {
                        ExperienceID = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(),
                        CompnayBusiness = c.String(),
                        CompanyLocation = c.String(),
                        Designation = c.String(),
                        Department = c.String(),
                        Responsibilities = c.String(),
                        StartDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        IsContinue = c.Boolean(nullable: false),
                        PersonalDetailID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ExperienceID)
                .ForeignKey("dbo.PersonalDetails", t => t.PersonalDetailID, cascadeDelete: true)
                .Index(t => t.PersonalDetailID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Experiences", "PersonalDetailID", "dbo.PersonalDetails");
            DropForeignKey("dbo.Trainings", "PersonalDetailID", "dbo.PersonalDetails");
            DropForeignKey("dbo.Skills", "PersonalDetailID", "dbo.PersonalDetails");
            DropForeignKey("dbo.Educations", "PersonalDetailID", "dbo.PersonalDetails");
            DropForeignKey("dbo.ApplyJobs", "PersonalDetailID", "dbo.PersonalDetails");
            DropForeignKey("dbo.JobLists", "EmployerID", "dbo.Employers");
            DropForeignKey("dbo.CompanyAddresses", "EmployerID", "dbo.Employers");
            DropForeignKey("dbo.ApplyJobs", "JobListID", "dbo.JobLists");
            DropForeignKey("dbo.Addresses", "PersonalDetailID", "dbo.PersonalDetails");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Experiences", new[] { "PersonalDetailID" });
            DropIndex("dbo.Trainings", new[] { "PersonalDetailID" });
            DropIndex("dbo.Skills", new[] { "PersonalDetailID" });
            DropIndex("dbo.Educations", new[] { "PersonalDetailID" });
            DropIndex("dbo.CompanyAddresses", new[] { "EmployerID" });
            DropIndex("dbo.JobLists", new[] { "EmployerID" });
            DropIndex("dbo.ApplyJobs", new[] { "PersonalDetailID" });
            DropIndex("dbo.ApplyJobs", new[] { "JobListID" });
            DropIndex("dbo.Addresses", new[] { "PersonalDetailID" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Experiences");
            DropTable("dbo.Trainings");
            DropTable("dbo.Skills");
            DropTable("dbo.Educations");
            DropTable("dbo.CompanyAddresses");
            DropTable("dbo.Employers");
            DropTable("dbo.JobLists");
            DropTable("dbo.ApplyJobs");
            DropTable("dbo.PersonalDetails");
            DropTable("dbo.Addresses");
        }
    }
}
