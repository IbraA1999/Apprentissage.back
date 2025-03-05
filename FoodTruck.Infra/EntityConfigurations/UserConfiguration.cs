using FoodTruck.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodTruck.Infra.EntityConfigurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.Property(u => u.Email).HasMaxLength(350);

            builder.Property(u => u.Password);

            builder.HasIndex(u => u.Email).IsUnique();

        }
    }
}
