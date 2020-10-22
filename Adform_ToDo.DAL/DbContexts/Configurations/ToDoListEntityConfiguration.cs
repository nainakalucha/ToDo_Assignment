using Adform_Todo.Common.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Adform_ToDo.DAL.DbContexts.Configurations
{
    internal class ToDoListEntityConfiguration : IEntityTypeConfiguration<TodoListEntity>
    {
        /// <summary>
        /// Configures ToDoListDbModel
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<TodoListEntity> builder)
        {
            builder.HasData(
                    new TodoListEntity
                    {
                        ToDoListId = 1,
                        Description = "List of movies to watch",
                        CreatedBy = 1,
                        CreationDate = DateTime.Now
                    },
                    new TodoListEntity
                    {
                        ToDoListId = 2,
                        Description = "List of movies to review",
                        CreatedBy = 1,
                        CreationDate = DateTime.Now
                    },
                    new TodoListEntity
                    {
                        ToDoListId = 3,
                        Description = "List of movies to pay",
                        CreatedBy = 1,
                        CreationDate = DateTime.Now
                    },
                    new TodoListEntity
                    {
                        ToDoListId = 4,
                        Description = "List of meals to cook",
                        CreatedBy = 1,
                        CreationDate = DateTime.Now
                    },
                    new TodoListEntity
                    {
                        ToDoListId = 5,
                        Description = "List of moview to watch",
                        CreatedBy = 1,
                        CreationDate = DateTime.Now
                    });
        }
    }
}