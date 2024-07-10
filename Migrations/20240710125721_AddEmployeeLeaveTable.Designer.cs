﻿// <auto-generated />
using System;
using EmployeeManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EmployeeManagement.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240710125721_AddEmployeeLeaveTable")]
    partial class AddEmployeeLeaveTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EmployeeManagement.Shared.ChatMessage", b =>
                {
                    b.Property<int>("ChatMessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ChatMessageId"), 1L, 1);

                    b.Property<string>("BotReply")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserMessage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ChatMessageId");

                    b.ToTable("ChatMessages");
                });

            modelBuilder.Entity("EmployeeManagement.Shared.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepartmentId"), 1L, 1);

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DepartmentId");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("EmployeeManagement.Shared.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"), 1L, 1);

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ManNumber")
                        .HasColumnType("int");

                    b.HasKey("EmployeeId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("EmployeeManagement.Shared.EmployeeLeave", b =>
                {
                    b.Property<int>("EmployeeLeaveId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeLeaveId"), 1L, 1);

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("LeaveDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.HasKey("EmployeeLeaveId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("EmployeeLeave");
                });

            modelBuilder.Entity("EmployeeManagement.Shared.Employee", b =>
                {
                    b.HasOne("EmployeeManagement.Shared.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("EmployeeManagement.Shared.EmployeeLeave", b =>
                {
                    b.HasOne("EmployeeManagement.Shared.Employee", "Employee")
                        .WithMany("EmployeeLeaves")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("EmployeeManagement.Shared.Department", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("EmployeeManagement.Shared.Employee", b =>
                {
                    b.Navigation("EmployeeLeaves");
                });
#pragma warning restore 612, 618
        }
    }
}
