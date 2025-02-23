﻿// <auto-generated />
using System;
using DL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DL.Migrations
{
    [DbContext(typeof(TutorConnectDBContext))]
    [Migration("20210804153957_MajorEntitiesRework")]
    partial class MajorEntitiesRework
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AppointmentUser", b =>
                {
                    b.Property<string>("AppointmentsId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UsersId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("AppointmentsId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("AppointmentUser");
                });

            modelBuilder.Entity("DL.Entities.Appointment", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("DL.Entities.Availability", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("AvailabilityEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("AvailabilityStart")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Availabilities");
                });

            modelBuilder.Entity("DL.Entities.DegreeCertification", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Details")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TutorId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("TutorId");

                    b.ToTable("DegreeCertifications");
                });

            modelBuilder.Entity("DL.Entities.Location", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("Latitude")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Longitude")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("DL.Entities.Message", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MessageBody")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReceiverId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SenderId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("TimeSent")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ReceiverId");

                    b.HasIndex("SenderId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("DL.Entities.Payment", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CreditCard")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("DL.Entities.Review", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Details")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<string>("TutorId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("TutorId");

                    b.HasIndex("UserId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("DL.Entities.Topic", b =>
                {
                    b.Property<string>("TopicName")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("TopicName");

                    b.ToTable("Topics");
                });

            modelBuilder.Entity("DL.Entities.Transaction", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("Amount")
                        .HasColumnType("money");

                    b.Property<string>("AppointmentId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Timestamp")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<string>("UserReceivedId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserSentId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("AppointmentId")
                        .IsUnique()
                        .HasFilter("[AppointmentId] IS NOT NULL");

                    b.HasIndex("UserReceivedId");

                    b.HasIndex("UserSentId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("DL.Entities.Tutor", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("HourlyRate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserId1")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.HasIndex("UserId1");

                    b.ToTable("Tutors");
                });

            modelBuilder.Entity("DL.Entities.TutorApplication", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("About")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Open")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Timestamp")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<string>("TutorId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("TutorId");

                    b.ToTable("TutorApplications");
                });

            modelBuilder.Entity("DL.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LocationId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("MessageId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.HasIndex("MessageId");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("TopicUser", b =>
                {
                    b.Property<string>("TopicsTopicName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UsersId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("TopicsTopicName", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("TopicUser");
                });

            modelBuilder.Entity("AppointmentUser", b =>
                {
                    b.HasOne("DL.Entities.Appointment", null)
                        .WithMany()
                        .HasForeignKey("AppointmentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DL.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DL.Entities.Availability", b =>
                {
                    b.HasOne("DL.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DL.Entities.DegreeCertification", b =>
                {
                    b.HasOne("DL.Entities.Tutor", null)
                        .WithMany("DegreesOrCerts")
                        .HasForeignKey("TutorId");
                });

            modelBuilder.Entity("DL.Entities.Message", b =>
                {
                    b.HasOne("DL.Entities.User", "Receiver")
                        .WithMany("MessagesReceived")
                        .HasForeignKey("ReceiverId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("DL.Entities.User", "Sender")
                        .WithMany("MessagesSent")
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Receiver");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("DL.Entities.Payment", b =>
                {
                    b.HasOne("DL.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DL.Entities.Review", b =>
                {
                    b.HasOne("DL.Entities.Tutor", "Tutor")
                        .WithMany("Reviews")
                        .HasForeignKey("TutorId");

                    b.HasOne("DL.Entities.User", null)
                        .WithMany("Reviews")
                        .HasForeignKey("UserId");

                    b.Navigation("Tutor");
                });

            modelBuilder.Entity("DL.Entities.Transaction", b =>
                {
                    b.HasOne("DL.Entities.Appointment", "Appointment")
                        .WithOne("Transaction")
                        .HasForeignKey("DL.Entities.Transaction", "AppointmentId");

                    b.HasOne("DL.Entities.User", "UserReceived")
                        .WithMany("TransactionsReceived")
                        .HasForeignKey("UserReceivedId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("DL.Entities.User", "UserSent")
                        .WithMany("TransactionsSent")
                        .HasForeignKey("UserSentId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Appointment");

                    b.Navigation("UserReceived");

                    b.Navigation("UserSent");
                });

            modelBuilder.Entity("DL.Entities.Tutor", b =>
                {
                    b.HasOne("DL.Entities.User", "User")
                        .WithOne("IsTutor")
                        .HasForeignKey("DL.Entities.Tutor", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DL.Entities.User", null)
                        .WithMany("Tutors")
                        .HasForeignKey("UserId1");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DL.Entities.TutorApplication", b =>
                {
                    b.HasOne("DL.Entities.Tutor", "Tutor")
                        .WithMany()
                        .HasForeignKey("TutorId");

                    b.Navigation("Tutor");
                });

            modelBuilder.Entity("DL.Entities.User", b =>
                {
                    b.HasOne("DL.Entities.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId");

                    b.HasOne("DL.Entities.Message", null)
                        .WithMany("Users")
                        .HasForeignKey("MessageId");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("DL.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("DL.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DL.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("DL.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TopicUser", b =>
                {
                    b.HasOne("DL.Entities.Topic", null)
                        .WithMany()
                        .HasForeignKey("TopicsTopicName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DL.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DL.Entities.Appointment", b =>
                {
                    b.Navigation("Transaction");
                });

            modelBuilder.Entity("DL.Entities.Message", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("DL.Entities.Tutor", b =>
                {
                    b.Navigation("DegreesOrCerts");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("DL.Entities.User", b =>
                {
                    b.Navigation("IsTutor");

                    b.Navigation("MessagesReceived");

                    b.Navigation("MessagesSent");

                    b.Navigation("Reviews");

                    b.Navigation("TransactionsReceived");

                    b.Navigation("TransactionsSent");

                    b.Navigation("Tutors");
                });
#pragma warning restore 612, 618
        }
    }
}
