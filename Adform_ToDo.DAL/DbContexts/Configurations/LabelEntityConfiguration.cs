using Adform_Todo.Common.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Adform_ToDo.DAL.DbContexts.Configurations
{
    internal class LabelEntityConfiguration : IEntityTypeConfiguration<LabelEntity>
    {
        /// <summary>
        /// COnfigures LabelDbModel
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<LabelEntity> builder)
        {
            builder.HasData(new LabelEntity
            {
                LabelId = 1,
                CreatedBy = 1,
                Description = "Review"
            },
            new LabelEntity
            {
                LabelId = 2,
                CreatedBy = 1,
                Description = "Watch"
            },
            new LabelEntity
            {
                LabelId = 3,
                CreatedBy = 1,
                Description = "Pay"
            },
            new LabelEntity
            {
                LabelId = 4,
                CreatedBy = 1,
                Description = "Criticise"
            });
        }
    }
}
