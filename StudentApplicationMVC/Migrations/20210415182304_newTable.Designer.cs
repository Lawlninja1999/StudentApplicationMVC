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
    [Migration("20210415182304_newTable")]
    partial class newTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StudentApplicationMVC.Models.AddUnitDetails", b =>
                {
                    b.Property<int>("AddUnitDetailsID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Assignment1")
                        .HasColumnType("int");

                    b.Property<int>("Assignment2")
                        .HasColumnType("int");

                    b.Property<int>("Exam")
                        .HasColumnType("int");

                    b.Property<string>("UnitCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UnitOutline")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UnitTitle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AddUnitDetailsID");

                    b.ToTable("addUnitDetails");
                });

            modelBuilder.Entity("StudentApplicationMVC.Models.LogIn", b =>
                {
                    b.Property<int>("LogInID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccessLevel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LogInID");

                    b.ToTable("LogIn");
                });
#pragma warning restore 612, 618
        }
    }
}
