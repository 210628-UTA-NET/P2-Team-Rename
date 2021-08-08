using Microsoft.EntityFrameworkCore.Migrations;

namespace DL.Migrations
{
    public partial class UpdateTutor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppointmentUser");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9090407f-1e30-43bc-91b3-36a61773c4c1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "989d3734-14e4-4a32-993b-6b36c69df643");

            migrationBuilder.AddColumn<double>(
                name: "Rating",
                table: "AspNetUsers",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MinuteLength",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "StudentId",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TutorId",
                table: "Appointments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "648decb2-b5dc-45dd-807e-e028722020ae", "eee1c715-5508-4dae-8ea3-347dd68cbe49", "Tutor", "TUTOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0e0db2d5-d051-440c-a880-62240bdd9bf1", "da730b88-9cb7-4d95-a125-bbe8e1936cb0", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_TutorId",
                table: "Appointments",
                column: "TutorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_AspNetUsers_TutorId",
                table: "Appointments",
                column: "TutorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_AspNetUsers_TutorId",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_TutorId",
                table: "Appointments");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0e0db2d5-d051-440c-a880-62240bdd9bf1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "648decb2-b5dc-45dd-807e-e028722020ae");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MinuteLength",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "TutorId",
                table: "Appointments");

            migrationBuilder.CreateTable(
                name: "AppointmentUser",
                columns: table => new
                {
                    AppointmentsId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UsersId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentUser", x => new { x.AppointmentsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_AppointmentUser_Appointments_AppointmentsId",
                        column: x => x.AppointmentsId,
                        principalTable: "Appointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppointmentUser_AspNetUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "989d3734-14e4-4a32-993b-6b36c69df643", "d8674d93-3656-49f9-a33d-98fdb334ab62", "Tutor", "TUTOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9090407f-1e30-43bc-91b3-36a61773c4c1", "1de40030-f03c-4d42-98a9-12f136726fe0", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentUser_UsersId",
                table: "AppointmentUser",
                column: "UsersId");
        }
    }
}
