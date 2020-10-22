using Adform_Todo.Common.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Adform_ToDo.DAL.DbContexts.Configurations
{
    internal class ToDoItemLabelsEntityConfiguration : IEntityTypeConfiguration<ToDoItemLabelsEntity>
    {
        /// <summary>
        /// Configures MapLabelsToItemDbModel
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<ToDoItemLabelsEntity> builder)
        {
            builder.ToTable("ToDoItemLabels");
            builder.HasKey(x => x.ItemMappingId);

            builder.HasOne(t => t.Users)
                .WithMany()
                .HasForeignKey(t => t.CreatedBy)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(t => t.Labels)
                .WithMany()
                .HasForeignKey(t => t.LabelId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(t => t.ToDoItems)
                .WithMany(t => t.Labels)
                .HasForeignKey(t => t.ToDoItemId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
