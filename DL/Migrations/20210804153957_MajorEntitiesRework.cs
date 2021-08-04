using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DL.Migrations
{
    public partial class MajorEntitiesRework : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentUser_Appointments_AppointmentsAppointmentID",
                table: "AppointmentUser");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Location_LocationID",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Appointments_AppointmentID",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_AspNetUsers_UserId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Tutors_AspNetUsers_UserID",
                table: "Tutors");

            migrationBuilder.DropTable(
                name: "MessageUser");

            migrationBuilder.DropIndex(
                name: "IX_Tutors_UserID",
                table: "Tutors");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_AppointmentID",
                table: "Transactions");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "542b3684-753b-4101-9a58-acc5822c9a1f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9967379d-771f-49c6-84f3-9698b5cde493");

            migrationBuilder.DropColumn(
                name: "RecieverID",
                table: "Messages");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Tutors",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "TutorID",
                table: "Tutors",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "AppointmentID",
                table: "Transactions",
                newName: "AppointmentId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Transactions",
                newName: "UserSentId");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Transactions",
                newName: "Timestamp");

            migrationBuilder.RenameColumn(
                name: "TransactionID",
                table: "Transactions",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_UserId",
                table: "Transactions",
                newName: "IX_Transactions_UserSentId");

            migrationBuilder.RenameColumn(
                name: "ReviewID",
                table: "Reviews",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PaymentID",
                table: "Payments",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "SenderID",
                table: "Messages",
                newName: "SenderId");

            migrationBuilder.RenameColumn(
                name: "MessageID",
                table: "Messages",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "LocationID",
                table: "Location",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "AvailabilityID",
                table: "Availabilities",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "LocationID",
                table: "AspNetUsers",
                newName: "LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_LocationID",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_LocationId");

            migrationBuilder.RenameColumn(
                name: "AppointmentsAppointmentID",
                table: "AppointmentUser",
                newName: "AppointmentsId");

            migrationBuilder.RenameColumn(
                name: "AppointmentID",
                table: "Appointments",
                newName: "Id");

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

            migrationBuilder.AddColumn<string>(
                name: "UserReceivedId",
                table: "Transactions",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TutorId",
                table: "Reviews",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SenderId",
                table: "Messages",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReceiverId",
                table: "Messages",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MessageId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DegreeCertifications",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TutorId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DegreeCertifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DegreeCertifications_Tutors_TutorId",
                        column: x => x.TutorId,
                        principalTable: "Tutors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TutorApplications",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TutorId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    About = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Open = table.Column<bool>(type: "bit", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TutorApplications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TutorApplications_Tutors_TutorId",
                        column: x => x.TutorId,
                        principalTable: "Tutors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tutors_UserId",
                table: "Tutors",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tutors_UserId1",
                table: "Tutors",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_AppointmentId",
                table: "Transactions",
                column: "AppointmentId",
                unique: true,
                filter: "[AppointmentId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_UserReceivedId",
                table: "Transactions",
                column: "UserReceivedId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_TutorId",
                table: "Reviews",
                column: "TutorId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ReceiverId",
                table: "Messages",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SenderId",
                table: "Messages",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_MessageId",
                table: "AspNetUsers",
                column: "MessageId");

            migrationBuilder.CreateIndex(
                name: "IX_DegreeCertifications_TutorId",
                table: "DegreeCertifications",
                column: "TutorId");

            migrationBuilder.CreateIndex(
                name: "IX_TutorApplications_TutorId",
                table: "TutorApplications",
                column: "TutorId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentUser_Appointments_AppointmentsId",
                table: "AppointmentUser",
                column: "AppointmentsId",
                principalTable: "Appointments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Location_LocationId",
                table: "AspNetUsers",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Messages_MessageId",
                table: "AspNetUsers",
                column: "MessageId",
                principalTable: "Messages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_AspNetUsers_ReceiverId",
                table: "Messages",
                column: "ReceiverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_AspNetUsers_SenderId",
                table: "Messages",
                column: "SenderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Tutors_TutorId",
                table: "Reviews",
                column: "TutorId",
                principalTable: "Tutors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Appointments_AppointmentId",
                table: "Transactions",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_AspNetUsers_UserReceivedId",
                table: "Transactions",
                column: "UserReceivedId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_AspNetUsers_UserSentId",
                table: "Transactions",
                column: "UserSentId",
                principalTable: "AspNetUsers",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentUser_Appointments_AppointmentsId",
                table: "AppointmentUser");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Location_LocationId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Messages_MessageId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_AspNetUsers_ReceiverId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_AspNetUsers_SenderId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Tutors_TutorId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Appointments_AppointmentId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_AspNetUsers_UserReceivedId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_AspNetUsers_UserSentId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Tutors_AspNetUsers_UserId",
                table: "Tutors");

            migrationBuilder.DropForeignKey(
                name: "FK_Tutors_AspNetUsers_UserId1",
                table: "Tutors");

            migrationBuilder.DropTable(
                name: "DegreeCertifications");

            migrationBuilder.DropTable(
                name: "TutorApplications");

            migrationBuilder.DropIndex(
                name: "IX_Tutors_UserId",
                table: "Tutors");

            migrationBuilder.DropIndex(
                name: "IX_Tutors_UserId1",
                table: "Tutors");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_AppointmentId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_UserReceivedId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_TutorId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Messages_ReceiverId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_SenderId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_MessageId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Tutors");

            migrationBuilder.DropColumn(
                name: "UserReceivedId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "TutorId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "ReceiverId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "MessageId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Tutors",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Tutors",
                newName: "TutorID");

            migrationBuilder.RenameColumn(
                name: "AppointmentId",
                table: "Transactions",
                newName: "AppointmentID");

            migrationBuilder.RenameColumn(
                name: "UserSentId",
                table: "Transactions",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Timestamp",
                table: "Transactions",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Transactions",
                newName: "TransactionID");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_UserSentId",
                table: "Transactions",
                newName: "IX_Transactions_UserId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Reviews",
                newName: "ReviewID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Payments",
                newName: "PaymentID");

            migrationBuilder.RenameColumn(
                name: "SenderId",
                table: "Messages",
                newName: "SenderID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Messages",
                newName: "MessageID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Location",
                newName: "LocationID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Availabilities",
                newName: "AvailabilityID");

            migrationBuilder.RenameColumn(
                name: "LocationId",
                table: "AspNetUsers",
                newName: "LocationID");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_LocationId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_LocationID");

            migrationBuilder.RenameColumn(
                name: "AppointmentsId",
                table: "AppointmentUser",
                newName: "AppointmentsAppointmentID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Appointments",
                newName: "AppointmentID");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "Tutors",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "SenderID",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RecieverID",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MessageUser",
                columns: table => new
                {
                    MessagesMessageID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UsersId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageUser", x => new { x.MessagesMessageID, x.UsersId });
                    table.ForeignKey(
                        name: "FK_MessageUser_AspNetUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MessageUser_Messages_MessagesMessageID",
                        column: x => x.MessagesMessageID,
                        principalTable: "Messages",
                        principalColumn: "MessageID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "542b3684-753b-4101-9a58-acc5822c9a1f", "a3065149-5e99-41db-8dea-c6725261bc01", "Tutor", "TUTOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9967379d-771f-49c6-84f3-9698b5cde493", "1b4f9750-d70c-4d67-9c44-82734277d6cf", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.CreateIndex(
                name: "IX_Tutors_UserID",
                table: "Tutors",
                column: "UserID",
                unique: true,
                filter: "[UserID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_AppointmentID",
                table: "Transactions",
                column: "AppointmentID",
                unique: true,
                filter: "[AppointmentID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_MessageUser_UsersId",
                table: "MessageUser",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentUser_Appointments_AppointmentsAppointmentID",
                table: "AppointmentUser",
                column: "AppointmentsAppointmentID",
                principalTable: "Appointments",
                principalColumn: "AppointmentID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Location_LocationID",
                table: "AspNetUsers",
                column: "LocationID",
                principalTable: "Location",
                principalColumn: "LocationID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Appointments_AppointmentID",
                table: "Transactions",
                column: "AppointmentID",
                principalTable: "Appointments",
                principalColumn: "AppointmentID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_AspNetUsers_UserId",
                table: "Transactions",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tutors_AspNetUsers_UserID",
                table: "Tutors",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
