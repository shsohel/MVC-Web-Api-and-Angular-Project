using Microsoft.EntityFrameworkCore.Migrations;

namespace JobCoreApi.Migrations
{
    public partial class hh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employers_CompanyAddresses_CompanyAddressID",
                table: "Employers");

            migrationBuilder.DropForeignKey(
                name: "FK_Employers_AspNetUsers_UserId",
                table: "Employers");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonalDetails_Addresses_AddressID",
                table: "PersonalDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonalDetails_Educations_EducationID",
                table: "PersonalDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonalDetails_Experiences_ExperienceID",
                table: "PersonalDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonalDetails_Skills_SkillID",
                table: "PersonalDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonalDetails_Trainings_TrainingID",
                table: "PersonalDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonalDetails_AspNetUsers_UserId",
                table: "PersonalDetails");

            migrationBuilder.DropIndex(
                name: "IX_PersonalDetails_AddressID",
                table: "PersonalDetails");

            migrationBuilder.DropIndex(
                name: "IX_PersonalDetails_EducationID",
                table: "PersonalDetails");

            migrationBuilder.DropIndex(
                name: "IX_PersonalDetails_ExperienceID",
                table: "PersonalDetails");

            migrationBuilder.DropIndex(
                name: "IX_PersonalDetails_SkillID",
                table: "PersonalDetails");

            migrationBuilder.DropIndex(
                name: "IX_PersonalDetails_TrainingID",
                table: "PersonalDetails");

            migrationBuilder.DropIndex(
                name: "IX_PersonalDetails_UserId",
                table: "PersonalDetails");

            migrationBuilder.DropIndex(
                name: "IX_Employers_CompanyAddressID",
                table: "Employers");

            migrationBuilder.DropIndex(
                name: "IX_Employers_UserId",
                table: "Employers");

            migrationBuilder.DropColumn(
                name: "AddressID",
                table: "PersonalDetails");

            migrationBuilder.DropColumn(
                name: "EducationID",
                table: "PersonalDetails");

            migrationBuilder.DropColumn(
                name: "ExperienceID",
                table: "PersonalDetails");

            migrationBuilder.DropColumn(
                name: "SkillID",
                table: "PersonalDetails");

            migrationBuilder.DropColumn(
                name: "TrainingID",
                table: "PersonalDetails");

            migrationBuilder.DropColumn(
                name: "Employee",
                table: "JobLists");

            migrationBuilder.DropColumn(
                name: "CompanyAddressID",
                table: "Employers");

            migrationBuilder.DropColumn(
                name: "Result",
                table: "Educations");

            migrationBuilder.AddColumn<int>(
                name: "PersonalDetailID",
                table: "Trainings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PersonalDetailID",
                table: "Skills",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "PersonalDetails",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CellPhone",
                table: "PersonalDetails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "PersonalDetails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FatherName",
                table: "PersonalDetails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "PersonalDetails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "PersonalDetails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MotherName",
                table: "PersonalDetails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NationalID",
                table: "PersonalDetails",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmployerID",
                table: "JobLists",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PersonalDetailID",
                table: "Experiences",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Employers",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PersonalDetailID",
                table: "Educations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EmployerID",
                table: "CompanyAddresses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PersonalDetailID",
                table: "Addresses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Trainings_PersonalDetailID",
                table: "Trainings",
                column: "PersonalDetailID");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_PersonalDetailID",
                table: "Skills",
                column: "PersonalDetailID");

            migrationBuilder.CreateIndex(
                name: "IX_JobLists_EmployerID",
                table: "JobLists",
                column: "EmployerID");

            migrationBuilder.CreateIndex(
                name: "IX_Experiences_PersonalDetailID",
                table: "Experiences",
                column: "PersonalDetailID");

            migrationBuilder.CreateIndex(
                name: "IX_Educations_PersonalDetailID",
                table: "Educations",
                column: "PersonalDetailID");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyAddresses_EmployerID",
                table: "CompanyAddresses",
                column: "EmployerID");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_PersonalDetailID",
                table: "Addresses",
                column: "PersonalDetailID");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_PersonalDetails_PersonalDetailID",
                table: "Addresses",
                column: "PersonalDetailID",
                principalTable: "PersonalDetails",
                principalColumn: "PersonalDetailID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyAddresses_Employers_EmployerID",
                table: "CompanyAddresses",
                column: "EmployerID",
                principalTable: "Employers",
                principalColumn: "EmployerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Educations_PersonalDetails_PersonalDetailID",
                table: "Educations",
                column: "PersonalDetailID",
                principalTable: "PersonalDetails",
                principalColumn: "PersonalDetailID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Experiences_PersonalDetails_PersonalDetailID",
                table: "Experiences",
                column: "PersonalDetailID",
                principalTable: "PersonalDetails",
                principalColumn: "PersonalDetailID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobLists_Employers_EmployerID",
                table: "JobLists",
                column: "EmployerID",
                principalTable: "Employers",
                principalColumn: "EmployerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_PersonalDetails_PersonalDetailID",
                table: "Skills",
                column: "PersonalDetailID",
                principalTable: "PersonalDetails",
                principalColumn: "PersonalDetailID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trainings_PersonalDetails_PersonalDetailID",
                table: "Trainings",
                column: "PersonalDetailID",
                principalTable: "PersonalDetails",
                principalColumn: "PersonalDetailID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_PersonalDetails_PersonalDetailID",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyAddresses_Employers_EmployerID",
                table: "CompanyAddresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Educations_PersonalDetails_PersonalDetailID",
                table: "Educations");

            migrationBuilder.DropForeignKey(
                name: "FK_Experiences_PersonalDetails_PersonalDetailID",
                table: "Experiences");

            migrationBuilder.DropForeignKey(
                name: "FK_JobLists_Employers_EmployerID",
                table: "JobLists");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_PersonalDetails_PersonalDetailID",
                table: "Skills");

            migrationBuilder.DropForeignKey(
                name: "FK_Trainings_PersonalDetails_PersonalDetailID",
                table: "Trainings");

            migrationBuilder.DropIndex(
                name: "IX_Trainings_PersonalDetailID",
                table: "Trainings");

            migrationBuilder.DropIndex(
                name: "IX_Skills_PersonalDetailID",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_JobLists_EmployerID",
                table: "JobLists");

            migrationBuilder.DropIndex(
                name: "IX_Experiences_PersonalDetailID",
                table: "Experiences");

            migrationBuilder.DropIndex(
                name: "IX_Educations_PersonalDetailID",
                table: "Educations");

            migrationBuilder.DropIndex(
                name: "IX_CompanyAddresses_EmployerID",
                table: "CompanyAddresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_PersonalDetailID",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "PersonalDetailID",
                table: "Trainings");

            migrationBuilder.DropColumn(
                name: "PersonalDetailID",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "CellPhone",
                table: "PersonalDetails");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "PersonalDetails");

            migrationBuilder.DropColumn(
                name: "FatherName",
                table: "PersonalDetails");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "PersonalDetails");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "PersonalDetails");

            migrationBuilder.DropColumn(
                name: "MotherName",
                table: "PersonalDetails");

            migrationBuilder.DropColumn(
                name: "NationalID",
                table: "PersonalDetails");

            migrationBuilder.DropColumn(
                name: "EmployerID",
                table: "JobLists");

            migrationBuilder.DropColumn(
                name: "PersonalDetailID",
                table: "Experiences");

            migrationBuilder.DropColumn(
                name: "PersonalDetailID",
                table: "Educations");

            migrationBuilder.DropColumn(
                name: "EmployerID",
                table: "CompanyAddresses");

            migrationBuilder.DropColumn(
                name: "PersonalDetailID",
                table: "Addresses");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "PersonalDetails",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AddressID",
                table: "PersonalDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EducationID",
                table: "PersonalDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ExperienceID",
                table: "PersonalDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SkillID",
                table: "PersonalDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TrainingID",
                table: "PersonalDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Employee",
                table: "JobLists",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Employers",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CompanyAddressID",
                table: "Employers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Result",
                table: "Educations",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersonalDetails_AddressID",
                table: "PersonalDetails",
                column: "AddressID");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalDetails_EducationID",
                table: "PersonalDetails",
                column: "EducationID");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalDetails_ExperienceID",
                table: "PersonalDetails",
                column: "ExperienceID");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalDetails_SkillID",
                table: "PersonalDetails",
                column: "SkillID");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalDetails_TrainingID",
                table: "PersonalDetails",
                column: "TrainingID");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalDetails_UserId",
                table: "PersonalDetails",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Employers_CompanyAddressID",
                table: "Employers",
                column: "CompanyAddressID");

            migrationBuilder.CreateIndex(
                name: "IX_Employers_UserId",
                table: "Employers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employers_CompanyAddresses_CompanyAddressID",
                table: "Employers",
                column: "CompanyAddressID",
                principalTable: "CompanyAddresses",
                principalColumn: "CompanyAddressID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employers_AspNetUsers_UserId",
                table: "Employers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalDetails_Addresses_AddressID",
                table: "PersonalDetails",
                column: "AddressID",
                principalTable: "Addresses",
                principalColumn: "AddressID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalDetails_Educations_EducationID",
                table: "PersonalDetails",
                column: "EducationID",
                principalTable: "Educations",
                principalColumn: "EducationID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalDetails_Experiences_ExperienceID",
                table: "PersonalDetails",
                column: "ExperienceID",
                principalTable: "Experiences",
                principalColumn: "ExperienceID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalDetails_Skills_SkillID",
                table: "PersonalDetails",
                column: "SkillID",
                principalTable: "Skills",
                principalColumn: "SkillID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalDetails_Trainings_TrainingID",
                table: "PersonalDetails",
                column: "TrainingID",
                principalTable: "Trainings",
                principalColumn: "TrainingID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalDetails_AspNetUsers_UserId",
                table: "PersonalDetails",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
