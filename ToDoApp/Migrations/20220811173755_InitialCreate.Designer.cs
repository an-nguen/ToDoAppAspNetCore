﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ToDoApp.Data;

#nullable disable

namespace ToDoApp.Migrations
{
    [DbContext(typeof(ToDoDbContext))]
    [Migration("20220811173755_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.8");

            modelBuilder.Entity("ToDoApp.Domains.Board", b =>
                {
                    b.Property<int>("BoardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("BoardId");

                    b.ToTable("Boards");
                });

            modelBuilder.Entity("ToDoApp.Domains.TaskCard", b =>
                {
                    b.Property<int>("TaskCardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CoverColor")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(30000)");

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("TaskListId")
                        .HasColumnType("INTEGER");

                    b.HasKey("TaskCardId");

                    b.HasIndex("TaskListId");

                    b.ToTable("TaskCards");
                });

            modelBuilder.Entity("ToDoApp.Domains.TaskList", b =>
                {
                    b.Property<int>("TaskListId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BoardId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("TaskListId");

                    b.HasIndex("BoardId");

                    b.ToTable("TaskLists");
                });

            modelBuilder.Entity("ToDoApp.Domains.TaskCard", b =>
                {
                    b.HasOne("ToDoApp.Domains.TaskList", "TaskList")
                        .WithMany("Cards")
                        .HasForeignKey("TaskListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TaskList");
                });

            modelBuilder.Entity("ToDoApp.Domains.TaskList", b =>
                {
                    b.HasOne("ToDoApp.Domains.Board", "Board")
                        .WithMany("TaskLists")
                        .HasForeignKey("BoardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Board");
                });

            modelBuilder.Entity("ToDoApp.Domains.Board", b =>
                {
                    b.Navigation("TaskLists");
                });

            modelBuilder.Entity("ToDoApp.Domains.TaskList", b =>
                {
                    b.Navigation("Cards");
                });
#pragma warning restore 612, 618
        }
    }
}
