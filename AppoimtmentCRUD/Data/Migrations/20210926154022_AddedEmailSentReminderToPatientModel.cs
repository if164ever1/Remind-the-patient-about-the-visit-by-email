using Microsoft.EntityFrameworkCore.Migrations;

namespace AppoimtmentCRUD.Data.Migrations
{
    public partial class AddedEmailSentReminderToPatientModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSendEmailRemainder",
                table: "Patients",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSendEmailRemainder",
                table: "Patients");
        }
    }
}
