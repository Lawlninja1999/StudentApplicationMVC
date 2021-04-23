﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudentApplicationMVC.Models;

namespace StudentApplicationMVC.Migrations
{
    [DbContext(typeof(ApplicationDataContext))]
    [Migration("20210421145053_newdd")]
    partial class newdd
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StudentApplicationMVC.Models.StudentDetails", b =>
                {
                    b.Property<int>("StudentDetailsID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccessLevel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Credits")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StudentNumber")
                        .HasColumnType("int");

                    b.Property<string>("StudentPhoto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudentDetailsID");

                    b.ToTable("StudentDetails");
                });

            modelBuilder.Entity("StudentApplicationMVC.Models.StudentGrades", b =>
                {
                    b.Property<int>("StudentGradesID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Assignment1")
                        .HasColumnType("int");

                    b.Property<int>("Assignment2")
                        .HasColumnType("int");

                    b.Property<int>("Exam")
                        .HasColumnType("int");

                    b.Property<string>("Semester")
                        .IsRequired()
                        .HasColumnType("nvarchar(2)")
                        .HasMaxLength(2);

                    b.Property<int>("StudentDetailsID")
                        .HasColumnType("int");

                    b.Property<int>("UnitDetailsID")
                        .HasColumnType("int");

                    b.HasKey("StudentGradesID");

                    b.HasIndex("StudentDetailsID");

                    b.HasIndex("UnitDetailsID");

                    b.ToTable("Grades");
                });

            modelBuilder.Entity("StudentApplicationMVC.Models.Teachers", b =>
                {
                    b.Property<int>("TeachersID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TeacherNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TeacherPhoto")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TeachersID");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("StudentApplicationMVC.Models.UnitDetails", b =>
                {
                    b.Property<int>("UnitDetailsID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Campus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TeachersID")
                        .HasColumnType("int");

                    b.Property<string>("UnitCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UnitTitle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UnitDetailsID");

                    b.HasIndex("TeachersID");

                    b.ToTable("UnitDetails");
                });

            modelBuilder.Entity("StudentApplicationMVC.Models.StudentGrades", b =>
                {
                    b.HasOne("StudentApplicationMVC.Models.StudentDetails", "Student")
                        .WithMany("Grades")
                        .HasForeignKey("StudentDetailsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentApplicationMVC.Models.UnitDetails", "Units")
                        .WithMany("Grades")
                        .HasForeignKey("UnitDetailsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StudentApplicationMVC.Models.UnitDetails", b =>
                {
                    b.HasOne("StudentApplicationMVC.Models.Teachers", "Teachers")
                        .WithMany("Units")
                        .HasForeignKey("TeachersID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
