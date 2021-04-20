﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudentApplicationMVC.Models;

namespace StudentApplicationMVC.Migrations
{
    [DbContext(typeof(ApplicationDataContext))]
    partial class ApplicationDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UnitDetailsID")
                        .HasColumnType("int");

                    b.HasKey("StudentGradesID");

                    b.HasIndex("UnitDetailsID");

                    b.ToTable("Grades");
                });

            modelBuilder.Entity("StudentApplicationMVC.Models.UnitDetails", b =>
                {
                    b.Property<int>("UnitDetailsID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Campus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Teacher")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UnitCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UnitTitle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UnitDetailsID");

                    b.ToTable("UnitDetails");
                });

            modelBuilder.Entity("StudentApplicationMVC.Models.StudentGrades", b =>
                {
                    b.HasOne("StudentApplicationMVC.Models.UnitDetails", "Units")
                        .WithMany("Grades")
                        .HasForeignKey("UnitDetailsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
