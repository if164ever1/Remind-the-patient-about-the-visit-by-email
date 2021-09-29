using Microsoft.EntityFrameworkCore.Migrations;

namespace AppoimtmentCRUD.Data.Migrations
{
    public partial class AddedEmailReminderToPatientModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAddEmailReminder",
                table: "Patients",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAddEmailReminder",
                table: "Patients");
        }
    }
}
