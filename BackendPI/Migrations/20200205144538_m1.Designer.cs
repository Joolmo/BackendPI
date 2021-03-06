﻿// <auto-generated />
using System;
using BackendPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BackendPI.Migrations
{
    [DbContext(typeof(BackendContext))]
    [Migration("20200205144538_m1")]
    partial class m1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("BackendPI.Models.Child", b =>
                {
                    b.Property<int>("Id");

                    b.Property<int?>("ClassroomId");

                    b.Property<string>("Name");

                    b.Property<string>("Surname");

                    b.HasKey("Id");

                    b.HasIndex("ClassroomId");

                    b.ToTable("Children");
                });

            modelBuilder.Entity("BackendPI.Models.ChildClassroom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ChildId");

                    b.Property<int>("ClasroomId");

                    b.Property<int?>("ClassroomId");

                    b.HasKey("Id");

                    b.HasIndex("ChildId");

                    b.HasIndex("ClassroomId");

                    b.ToTable("ChildClassroom");
                });

            modelBuilder.Entity("BackendPI.Models.Classroom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Classrooms");
                });

            modelBuilder.Entity("BackendPI.Models.Report", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ChildId");

                    b.Property<string>("Description");

                    b.Property<int>("IdChildren");

                    b.HasKey("Id");

                    b.HasIndex("ChildId");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("BackendPI.Models.Teacher", b =>
                {
                    b.Property<int>("Id");

                    b.Property<int?>("ClassroomId");

                    b.Property<string>("Name");

                    b.Property<string>("Surname");

                    b.HasKey("Id");

                    b.HasIndex("ClassroomId");

                    b.ToTable("Teacher");
                });

            modelBuilder.Entity("BackendPI.Models.TeacherClassroom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClasroomId");

                    b.Property<int?>("ClassroomId");

                    b.Property<int>("TeacherId");

                    b.HasKey("Id");

                    b.HasIndex("ClassroomId");

                    b.HasIndex("TeacherId");

                    b.ToTable("TeacherClassroom");
                });

            modelBuilder.Entity("BackendPI.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Password");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BackendPI.Models.Child", b =>
                {
                    b.HasOne("BackendPI.Models.Classroom")
                        .WithMany("Children")
                        .HasForeignKey("ClassroomId");

                    b.HasOne("BackendPI.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BackendPI.Models.ChildClassroom", b =>
                {
                    b.HasOne("BackendPI.Models.Child", "Child")
                        .WithMany("Classrooms")
                        .HasForeignKey("ChildId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BackendPI.Models.Classroom", "Classroom")
                        .WithMany()
                        .HasForeignKey("ClassroomId");
                });

            modelBuilder.Entity("BackendPI.Models.Report", b =>
                {
                    b.HasOne("BackendPI.Models.Child")
                        .WithMany("Reports")
                        .HasForeignKey("ChildId");
                });

            modelBuilder.Entity("BackendPI.Models.Teacher", b =>
                {
                    b.HasOne("BackendPI.Models.Classroom")
                        .WithMany("Teachers")
                        .HasForeignKey("ClassroomId");

                    b.HasOne("BackendPI.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BackendPI.Models.TeacherClassroom", b =>
                {
                    b.HasOne("BackendPI.Models.Classroom", "Classroom")
                        .WithMany()
                        .HasForeignKey("ClassroomId");

                    b.HasOne("BackendPI.Models.Teacher", "Teacher")
                        .WithMany("Classrooms")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
