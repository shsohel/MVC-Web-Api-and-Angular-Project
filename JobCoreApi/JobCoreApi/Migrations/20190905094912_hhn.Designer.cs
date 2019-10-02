﻿// <auto-generated />
using System;
using JobCoreApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace JobCoreApi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190905094912_hhn")]
    partial class hhn
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("JobCoreApi.Models.Address", b =>
                {
                    b.Property<int>("AddressID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PermanentAddress");

                    b.Property<int>("PersonalDetailID");

                    b.Property<string>("PresentAddress");

                    b.HasKey("AddressID");

                    b.HasIndex("PersonalDetailID");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("JobCoreApi.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("JobCoreApi.Models.ApplyJob", b =>
                {
                    b.Property<int>("ApplyJobID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("JobListID");

                    b.Property<int>("PersonalDetailID");

                    b.HasKey("ApplyJobID");

                    b.HasIndex("JobListID");

                    b.HasIndex("PersonalDetailID");

                    b.ToTable("ApplyJobs");
                });

            modelBuilder.Entity("JobCoreApi.Models.CompanyAddress", b =>
                {
                    b.Property<int>("CompanyAddressID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddressDetails");

                    b.Property<string>("Country");

                    b.Property<string>("District");

                    b.Property<int>("EmployerID");

                    b.Property<string>("Thana");

                    b.HasKey("CompanyAddressID");

                    b.HasIndex("EmployerID");

                    b.ToTable("CompanyAddresses");
                });

            modelBuilder.Entity("JobCoreApi.Models.Education", b =>
                {
                    b.Property<int>("EducationID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Achievement");

                    b.Property<string>("CGPA");

                    b.Property<string>("DegreeTitle");

                    b.Property<string>("Duration");

                    b.Property<string>("Group");

                    b.Property<string>("Institute");

                    b.Property<string>("LevelOfEducation");

                    b.Property<string>("PassingYear");

                    b.Property<int>("PersonalDetailID");

                    b.Property<string>("Scale");

                    b.HasKey("EducationID");

                    b.HasIndex("PersonalDetailID");

                    b.ToTable("Educations");
                });

            modelBuilder.Entity("JobCoreApi.Models.Employer", b =>
                {
                    b.Property<int>("EmployerID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BusinessDescription");

                    b.Property<string>("Catageory");

                    b.Property<string>("CompanyName");

                    b.Property<string>("Email");

                    b.Property<string>("Fax");

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("TelePhone");

                    b.Property<string>("UserId");

                    b.Property<string>("UserName");

                    b.Property<string>("WebsiteUrl");

                    b.HasKey("EmployerID");

                    b.ToTable("Employers");
                });

            modelBuilder.Entity("JobCoreApi.Models.Experience", b =>
                {
                    b.Property<int>("ExperienceID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompanyLocation");

                    b.Property<string>("CompanyName");

                    b.Property<string>("CompnayBusiness");

                    b.Property<string>("Department");

                    b.Property<string>("Designation");

                    b.Property<DateTime>("EndDate");

                    b.Property<bool>("IsContinue");

                    b.Property<int>("PersonalDetailID");

                    b.Property<string>("Responsibilities");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("ExperienceID");

                    b.HasIndex("PersonalDetailID");

                    b.ToTable("Experiences");
                });

            modelBuilder.Entity("JobCoreApi.Models.JobList", b =>
                {
                    b.Property<int>("JobListID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AgeLimit");

                    b.Property<string>("EducationRequirement");

                    b.Property<int>("EmployerID");

                    b.Property<bool>("IsApprove");

                    b.Property<DateTime>("LastDateofApplication");

                    b.Property<int>("NumberofPost");

                    b.Property<string>("Position");

                    b.Property<string>("SalaryScale");

                    b.HasKey("JobListID");

                    b.HasIndex("EmployerID");

                    b.ToTable("JobLists");
                });

            modelBuilder.Entity("JobCoreApi.Models.PersonalDetail", b =>
                {
                    b.Property<int>("PersonalDetailID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CellPhone");

                    b.Property<string>("Email");

                    b.Property<string>("FatherName");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("MotherName");

                    b.Property<string>("NationalID");

                    b.Property<string>("UserId");

                    b.Property<string>("UserName");

                    b.HasKey("PersonalDetailID");

                    b.ToTable("PersonalDetails");
                });

            modelBuilder.Entity("JobCoreApi.Models.Skill", b =>
                {
                    b.Property<int>("SkillID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PersonalDetailID");

                    b.Property<string>("SkillName");

                    b.HasKey("SkillID");

                    b.HasIndex("PersonalDetailID");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("JobCoreApi.Models.Training", b =>
                {
                    b.Property<int>("TrainingID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Country");

                    b.Property<string>("Duration");

                    b.Property<string>("Institute");

                    b.Property<string>("Location");

                    b.Property<int>("PersonalDetailID");

                    b.Property<string>("Title");

                    b.Property<string>("Topics");

                    b.Property<string>("TrainingYear");

                    b.HasKey("TrainingID");

                    b.HasIndex("PersonalDetailID");

                    b.ToTable("Trainings");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("JobCoreApi.Models.Address", b =>
                {
                    b.HasOne("JobCoreApi.Models.PersonalDetail", "PersonalDetail")
                        .WithMany("Addresses")
                        .HasForeignKey("PersonalDetailID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("JobCoreApi.Models.ApplyJob", b =>
                {
                    b.HasOne("JobCoreApi.Models.JobList", "JobList")
                        .WithMany("ApplyJobs")
                        .HasForeignKey("JobListID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("JobCoreApi.Models.PersonalDetail", "PersonalDetail")
                        .WithMany("ApplyJobs")
                        .HasForeignKey("PersonalDetailID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("JobCoreApi.Models.CompanyAddress", b =>
                {
                    b.HasOne("JobCoreApi.Models.Employer", "Employer")
                        .WithMany("CompanyAddresses")
                        .HasForeignKey("EmployerID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("JobCoreApi.Models.Education", b =>
                {
                    b.HasOne("JobCoreApi.Models.PersonalDetail", "PersonalDetail")
                        .WithMany("Educations")
                        .HasForeignKey("PersonalDetailID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("JobCoreApi.Models.Experience", b =>
                {
                    b.HasOne("JobCoreApi.Models.PersonalDetail", "PersonalDetail")
                        .WithMany()
                        .HasForeignKey("PersonalDetailID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("JobCoreApi.Models.JobList", b =>
                {
                    b.HasOne("JobCoreApi.Models.Employer", "Employer")
                        .WithMany("JobLists")
                        .HasForeignKey("EmployerID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("JobCoreApi.Models.Skill", b =>
                {
                    b.HasOne("JobCoreApi.Models.PersonalDetail", "PersonalDetail")
                        .WithMany("Skills")
                        .HasForeignKey("PersonalDetailID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("JobCoreApi.Models.Training", b =>
                {
                    b.HasOne("JobCoreApi.Models.PersonalDetail", "PersonalDetail")
                        .WithMany("Trainings")
                        .HasForeignKey("PersonalDetailID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("JobCoreApi.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("JobCoreApi.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("JobCoreApi.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("JobCoreApi.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
