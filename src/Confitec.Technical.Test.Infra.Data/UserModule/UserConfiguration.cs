using Confitec.Technical.Test.Domain.UserModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Confitec.Technical.Test.Infra.Data.UserModule
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users", "dbo");
            
            builder.HasKey(p => p.ID);

            builder.Property(p => p.Name).HasColumnType("varchar").HasMaxLength(255).IsRequired(true);
            builder.Property(p => p.Surname).HasColumnType("varchar").HasMaxLength(255).IsRequired(true);
            builder.Property(p => p.Mail).HasColumnType("varchar").HasMaxLength(255).IsRequired(true);
            builder.Property(p => p.BirthDate).HasColumnType("datetime").IsRequired(true);
            builder.Property(p => p.Scholarity).HasColumnType("tinyint").IsRequired(true);
        }
    }
}
