using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DL.Migrations
{
    public partial class MinorFixes21 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TutorApplications_Tutors_TutorId",
                table: "TutorApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_Tutors_AspNetUsers_UserId",
                table: "Tutors");

            migrationBuilder.DropForeignKey(
                name: "FK_Tutors_AspNetUsers_UserId1",
                table: "Tutors");

            migrationBuilder.DropIndex(
                name: "IX_Tutors_UserId",
                table: "Tutors");

            migrationBuilder.DropIndex(
                name: "IX_Tutors_UserId1",
                table: "Tutors");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Tutors");

            migrationBuilder.RenameColumn(
                name: "TutorId",
                table: "TutorApplications",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_TutorApplications_TutorId",
                table: "TutorApplications",
                newName: "IX_TutorApplications_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Tutors",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "About",
                table: "Tutors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserAccountId",
                table: "Tutors",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TutorApplicationId",
                table: "Topics",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TutorId",
                table: "Topics",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TutorApplicationId",
                table: "DegreeCertifications",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ChatMessage",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SenderId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReceiverId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SenderName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatMessage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChatMessage_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tutors_UserAccountId",
                table: "Tutors",
                column: "UserAccountId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tutors_UserId",
                table: "Tutors",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Topics_TutorApplicationId",
                table: "Topics",
                column: "TutorApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Topics_TutorId",
                table: "Topics",
                column: "TutorId");

            migrationBuilder.CreateIndex(
                name: "IX_DegreeCertifications_TutorApplicationId",
                table: "DegreeCertifications",
                column: "TutorApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessage_UserId",
                table: "ChatMessage",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_DegreeCertifications_TutorApplications_TutorApplicationId",
                table: "DegreeCertifications",
                column: "TutorApplicationId",
                principalTable: "TutorApplications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Topics_TutorApplications_TutorApplicationId",
                table: "Topics",
                column: "TutorApplicationId",
                principalTable: "TutorApplications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Topics_Tutors_TutorId",
                table: "Topics",
                column: "TutorId",
                principalTable: "Tutors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TutorApplications_AspNetUsers_UserId",
                table: "TutorApplications",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tutors_AspNetUsers_UserAccountId",
                table: "Tutors",
                column: "UserAccountId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tutors_AspNetUsers_UserId",
                table: "Tutors",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DegreeCertifications_TutorApplications_TutorApplicationId",
                table: "DegreeCertifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Topics_TutorApplications_TutorApplicationId",
                table: "Topics");

            migrationBuilder.DropForeignKey(
                name: "FK_Topics_Tutors_TutorId",
                table: "Topics");

            migrationBuilder.DropForeignKey(
                name: "FK_TutorApplications_AspNetUsers_UserId",
                table: "TutorApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_Tutors_AspNetUsers_UserAccountId",
                table: "Tutors");

            migrationBuilder.DropForeignKey(
                name: "FK_Tutors_AspNetUsers_UserId",
                table: "Tutors");

            migrationBuilder.DropTable(
                name: "ChatMessage");

            migrationBuilder.DropIndex(
                name: "IX_Tutors_UserAccountId",
                table: "Tutors");

            migrationBuilder.DropIndex(
                name: "IX_Tutors_UserId",
                table: "Tutors");

            migrationBuilder.DropIndex(
                name: "IX_Topics_TutorApplicationId",
                table: "Topics");

            migrationBuilder.DropIndex(
                name: "IX_Topics_TutorId",
                table: "Topics");

            migrationBuilder.DropIndex(
                name: "IX_DegreeCertifications_TutorApplicationId",
                table: "DegreeCertifications");

            migrationBuilder.DropColumn(
                name: "About",
                table: "Tutors");

            migrationBuilder.DropColumn(
                name: "UserAccountId",
                table: "Tutors");

            migrationBuilder.DropColumn(
                name: "TutorApplicationId",
                table: "Topics");

            migrationBuilder.DropColumn(
                name: "TutorId",
                table: "Topics");

            migrationBuilder.DropColumn(
                name: "TutorApplicationId",
                table: "DegreeCertifications");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "TutorApplications",
                newName: "TutorId");

            migrationBuilder.RenameIndex(
                name: "IX_TutorApplications_UserId",
                table: "TutorApplications",
                newName: "IX_TutorApplications_TutorId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Tutors",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Tutors",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tutors_UserId",
                table: "Tutors",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tutors_UserId1",
                table: "Tutors",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_TutorApplications_Tutors_TutorId",
                table: "TutorApplications",
                column: "TutorId",
                principalTable: "Tutors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tutors_AspNetUsers_UserId",
                table: "Tutors",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tutors_AspNetUsers_UserId1",
                table: "Tutors",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
