using Microsoft.EntityFrameworkCore.Migrations;

namespace DL.Migrations
{
    public partial class TimeRename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "069de705-39cd-496a-a3cf-0b17a91b9ac6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "30069111-cdbd-4b39-9391-51f9fb454a9a");

            migrationBuilder.RenameColumn(
                name: "Timestamp",
                table: "Messages",
                newName: "TimeSent");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "137162ef-bc77-400e-b863-64d5b3d810a1", "6986cc60-4fc3-4d6e-a9cd-99d4955250d7", "Tutor", "TUTOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "426cfd88-3444-4248-b1ae-1b4ad05d455e", "5da74755-fb76-48b1-a8e2-2547d48bcb49", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "137162ef-bc77-400e-b863-64d5b3d810a1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "426cfd88-3444-4248-b1ae-1b4ad05d455e");

            migrationBuilder.RenameColumn(
                name: "TimeSent",
                table: "Messages",
                newName: "Timestamp");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "069de705-39cd-496a-a3cf-0b17a91b9ac6", "6465ae18-e8d4-4d8d-a0ae-698956d5ec0f", "Tutor", "TUTOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "30069111-cdbd-4b39-9391-51f9fb454a9a", "e56a38fc-167f-47ab-8887-5ce429ca2302", "Administrator", "ADMINISTRATOR" });
        }
    }
}
