using Adform_Todo.Common.Helpers;
using Adform_Todo.Common.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Adform_ToDo.DAL.DbContexts.Configurations
{
    internal class UserEntityConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        /// <summary>
        /// Inserts initial user records since other tables have dependency on it.
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasData(new UserEntity
            {
                UserId = 1,
                FirstName = "Sunaina",
                LastName = "Kalucha",
                UserName = "Sunaina",
                Password = CommonHelper.EncodePasswordToBase64("12345"),
                UserRole = "Admin"
            });
        }
    }
}
