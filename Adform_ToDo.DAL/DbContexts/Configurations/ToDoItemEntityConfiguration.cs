using Adform_Todo.Common.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Adform_ToDo.DAL.DbContexts.Configurations
{
    internal class ToDoItemEntityConfiguration : IEntityTypeConfiguration<TodoItemEntity>
    {
        /// <summary>
        /// Configures ToDoItemDbModel
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<TodoItemEntity> builder)
        {
            builder.ToTable("ToDoItems");
            builder.HasKey(x => x.ToDoItemId);

            builder.HasOne(t => t.ToDoLists)
                   .WithMany(t => t.ToDoItems)
                   .HasForeignKey(t => t.ToDoListId)
                   .OnDelete(DeleteBehavior.Restrict);
            builder.HasData(
                    new TodoItemEntity
                    {
                        ToDoItemId = 1,
                        Notes = "Watch horror movies",
                        ToDoListId = 1,
                        CreatedBy = 1,
                        CreationDate = DateTime.Now
                    },
                    new TodoItemEntity
                    {
                        ToDoItemId = 2,
                        Notes = "Review action movies",
                        ToDoListId = 2,
                        CreatedBy = 1,
                        CreationDate = DateTime.Now
                    },
                    new TodoItemEntity
                    {
                        ToDoItemId = 3,
                        Notes = "Pay romantic movies",
                        ToDoListId = 3,
                        CreatedBy = 1,
                        CreationDate = DateTime.Now
                    },
                    new TodoItemEntity
                    {
                        ToDoItemId = 4,
                        Notes = "Review thriller movies",
                        ToDoListId = 2,
                        CreatedBy = 1,
                        CreationDate = DateTime.Now
                    },
                    new TodoItemEntity
                    {
                        ToDoItemId = 5,
                        Notes = "Watch Kids Movies",
                        ToDoListId = 1,
                        CreatedBy = 1,
                        CreationDate = DateTime.Now
                    });
        }
    }
}

