using Microsoft.EntityFrameworkCore.Migrations;

namespace DL.Migrations
{
    public partial class Roles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "542b3684-753b-4101-9a58-acc5822c9a1f", "a3065149-5e99-41db-8dea-c6725261bc01", "Tutor", "TUTOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9967379d-771f-49c6-84f3-9698b5cde493", "1b4f9750-d70c-4d67-9c44-82734277d6cf", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "542b3684-753b-4101-9a58-acc5822c9a1f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9967379d-771f-49c6-84f3-9698b5cde493");
        }
    }
}
