using Microsoft.EntityFrameworkCore.Migrations;

namespace DL.Migrations
{
    public partial class ModifyRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "989d3734-14e4-4a32-993b-6b36c69df643", "d8674d93-3656-49f9-a33d-98fdb334ab62", "Tutor", "TUTOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9090407f-1e30-43bc-91b3-36a61773c4c1", "1de40030-f03c-4d42-98a9-12f136726fe0", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9090407f-1e30-43bc-91b3-36a61773c4c1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "989d3734-14e4-4a32-993b-6b36c69df643");
        }
    }
}
