using Adform_Todo.Common.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Adform_ToDo.DAL.DbContexts.Configurations
{
    internal class ToDoListLabelsEntityConfiguration : IEntityTypeConfiguration<ToDoListLabelsEntity>
    {
        /// <summary>
        /// Configures MapLabelsToListDbModel
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<ToDoListLabelsEntity> builder)
        {
            builder.ToTable("ToDoListLabels");
            builder.HasKey(x => x.ListMappingId);

            builder.HasOne(t => t.Users)
                .WithMany()
                .HasForeignKey(t => t.CreatedBy)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(t => t.Labels)
                .WithMany()
                .HasForeignKey(t => t.LabelId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(t => t.ToDoLists)
                .WithMany(t => t.Labels)
                .HasForeignKey(t => t.ToDoListId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
