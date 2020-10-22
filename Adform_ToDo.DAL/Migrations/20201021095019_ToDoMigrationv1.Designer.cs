﻿// <auto-generated />
using System;
using Adform_ToDo.DAL.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Adform_ToDo.DAL.Migrations
{
    [DbContext(typeof(ToDoDbContext))]
    [Migration("20201021095019_ToDoMigrationv1")]
    partial class ToDoMigrationv1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Adform_Todo.Common.Models.LabelEntity", b =>
                {
                    b.Property<long>("LabelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LabelId");

                    b.HasIndex("CreatedBy");

                    b.ToTable("Labels");

                    b.HasData(
                        new
                        {
                            LabelId = 1L,
                            CreatedBy = 1L,
                            Description = "Review"
                        },
                        new
                        {
                            LabelId = 2L,
                            CreatedBy = 1L,
                            Description = "Watch"
                        },
                        new
                        {
                            LabelId = 3L,
                            CreatedBy = 1L,
                            Description = "Pay"
                        },
                        new
                        {
                            LabelId = 4L,
                            CreatedBy = 1L,
                            Description = "Criticise"
                        });
                });

            modelBuilder.Entity("Adform_Todo.Common.Models.ToDoItemLabelsEntity", b =>
                {
                    b.Property<long>("ItemMappingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<long>("LabelId")
                        .HasColumnType("bigint");

                    b.Property<long>("ToDoItemId")
                        .HasColumnType("bigint");

                    b.HasKey("ItemMappingId");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("LabelId");

                    b.HasIndex("ToDoItemId");

                    b.ToTable("ToDoItemLabels");
                });

            modelBuilder.Entity("Adform_Todo.Common.Models.ToDoListLabelsEntity", b =>
                {
                    b.Property<long>("ListMappingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<long>("LabelId")
                        .HasColumnType("bigint");

                    b.Property<long>("ToDoListId")
                        .HasColumnType("bigint");

                    b.HasKey("ListMappingId");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("LabelId");

                    b.HasIndex("ToDoListId");

                    b.ToTable("ToDoListLabels");
                });

            modelBuilder.Entity("Adform_Todo.Common.Models.TodoItemEntity", b =>
                {
                    b.Property<long>("ToDoItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ToDoListId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdationDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ToDoItemId");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("ToDoListId");

                    b.ToTable("ToDoItems");

                    b.HasData(
                        new
                        {
                            ToDoItemId = 1L,
                            CreatedBy = 1L,
                            CreationDate = new DateTime(2020, 10, 21, 15, 20, 18, 905, DateTimeKind.Local).AddTicks(654),
                            Notes = "Watch horror movies",
                            ToDoListId = 1L
                        },
                        new
                        {
                            ToDoItemId = 2L,
                            CreatedBy = 1L,
                            CreationDate = new DateTime(2020, 10, 21, 15, 20, 18, 905, DateTimeKind.Local).AddTicks(1319),
                            Notes = "Review action movies",
                            ToDoListId = 2L
                        },
                        new
                        {
                            ToDoItemId = 3L,
                            CreatedBy = 1L,
                            CreationDate = new DateTime(2020, 10, 21, 15, 20, 18, 905, DateTimeKind.Local).AddTicks(1342),
                            Notes = "Pay romantic movies",
                            ToDoListId = 3L
                        },
                        new
                        {
                            ToDoItemId = 4L,
                            CreatedBy = 1L,
                            CreationDate = new DateTime(2020, 10, 21, 15, 20, 18, 905, DateTimeKind.Local).AddTicks(1345),
                            Notes = "Review thriller movies",
                            ToDoListId = 2L
                        },
                        new
                        {
                            ToDoItemId = 5L,
                            CreatedBy = 1L,
                            CreationDate = new DateTime(2020, 10, 21, 15, 20, 18, 905, DateTimeKind.Local).AddTicks(1347),
                            Notes = "Watch Kids Movies",
                            ToDoListId = 1L
                        });
                });

            modelBuilder.Entity("Adform_Todo.Common.Models.TodoListEntity", b =>
                {
                    b.Property<long>("ToDoListId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdationDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ToDoListId");

                    b.HasIndex("CreatedBy");

                    b.ToTable("ToDoLists");

                    b.HasData(
                        new
                        {
                            ToDoListId = 1L,
                            CreatedBy = 1L,
                            CreationDate = new DateTime(2020, 10, 21, 15, 20, 18, 890, DateTimeKind.Local).AddTicks(4183),
                            Description = "List of movies to watch"
                        },
                        new
                        {
                            ToDoListId = 2L,
                            CreatedBy = 1L,
                            CreationDate = new DateTime(2020, 10, 21, 15, 20, 18, 892, DateTimeKind.Local).AddTicks(182),
                            Description = "List of movies to review"
                        },
                        new
                        {
                            ToDoListId = 3L,
                            CreatedBy = 1L,
                            CreationDate = new DateTime(2020, 10, 21, 15, 20, 18, 892, DateTimeKind.Local).AddTicks(233),
                            Description = "List of movies to pay"
                        },
                        new
                        {
                            ToDoListId = 4L,
                            CreatedBy = 1L,
                            CreationDate = new DateTime(2020, 10, 21, 15, 20, 18, 892, DateTimeKind.Local).AddTicks(236),
                            Description = "List of meals to cook"
                        },
                        new
                        {
                            ToDoListId = 5L,
                            CreatedBy = 1L,
                            CreationDate = new DateTime(2020, 10, 21, 15, 20, 18, 892, DateTimeKind.Local).AddTicks(238),
                            Description = "List of moview to watch"
                        });
                });

            modelBuilder.Entity("Adform_Todo.Common.Models.UserEntity", b =>
                {
                    b.Property<long>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserRole")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1L,
                            FirstName = "Sunaina",
                            LastName = "Kalucha",
                            Password = "MTIzNDU=",
                            UserName = "Sunaina",
                            UserRole = "Admin"
                        });
                });

            modelBuilder.Entity("Adform_Todo.Common.Models.LabelEntity", b =>
                {
                    b.HasOne("Adform_Todo.Common.Models.UserEntity", "Users")
                        .WithMany()
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Adform_Todo.Common.Models.ToDoItemLabelsEntity", b =>
                {
                    b.HasOne("Adform_Todo.Common.Models.UserEntity", "Users")
                        .WithMany()
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Adform_Todo.Common.Models.LabelEntity", "Labels")
                        .WithMany()
                        .HasForeignKey("LabelId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Adform_Todo.Common.Models.TodoItemEntity", "ToDoItems")
                        .WithMany("Labels")
                        .HasForeignKey("ToDoItemId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Adform_Todo.Common.Models.ToDoListLabelsEntity", b =>
                {
                    b.HasOne("Adform_Todo.Common.Models.UserEntity", "Users")
                        .WithMany()
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Adform_Todo.Common.Models.LabelEntity", "Labels")
                        .WithMany()
                        .HasForeignKey("LabelId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Adform_Todo.Common.Models.TodoListEntity", "ToDoLists")
                        .WithMany("Labels")
                        .HasForeignKey("ToDoListId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Adform_Todo.Common.Models.TodoItemEntity", b =>
                {
                    b.HasOne("Adform_Todo.Common.Models.UserEntity", "Users")
                        .WithMany()
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Adform_Todo.Common.Models.TodoListEntity", "ToDoLists")
                        .WithMany("ToDoItems")
                        .HasForeignKey("ToDoListId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Adform_Todo.Common.Models.TodoListEntity", b =>
                {
                    b.HasOne("Adform_Todo.Common.Models.UserEntity", "Users")
                        .WithMany()
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
