using Adform_Todo.Common.Models;
using Adform_ToDo.DAL.DbContexts.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Adform_ToDo.DAL.DbContexts
{
    public class ToDoDbContext : DbContext
    {
        /// <summary>
        /// Default Constructor required to enable Migrations
        /// </summary>
        public ToDoDbContext()
        {
        }

        public ToDoDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<TodoListEntity> ToDoLists { get; set; }
        public DbSet<TodoItemEntity> ToDoItems { get; set; }
        public DbSet<LabelEntity> Labels { get; set; }
        public DbSet<ToDoListLabelsEntity> ToDoListLabels { get; set; }
        public DbSet<ToDoItemLabelsEntity> ToDoItemLabels { get; set; }

        /// <summary>
        /// This method configures the database (and other options) to be used for ToDoDbContext.
        /// This method is called for each instance of the context that is created.
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string envName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
                IConfigurationRoot configuration = new ConfigurationBuilder()
                     .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
                     .AddJsonFile($"appsettings.{envName}.json", optional: false)
                    .Build();
                string connectionString = configuration.GetConnectionString("ToDoDbConnString");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
        /// <summary>
        /// All DbSet entities are configured in this method.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ToDoListEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ToDoItemEntityConfiguration());
            modelBuilder.ApplyConfiguration(new LabelEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ToDoListLabelsEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ToDoItemLabelsEntityConfiguration());
        }
    }
}
