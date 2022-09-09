using Confitec.Technical.Test.Domain.SystemUserModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Confitec.Technical.Test.Infra.Data.UserModule
{
    public class RecoveryPasswordConfiguration : IEntityTypeConfiguration<SystemUser>
    {
        public void Configure(EntityTypeBuilder<SystemUser> builder)
        {
            builder.ToTable("SystemUsers", "dbo");
            
            builder.HasKey(p => p.ID);

            builder.Property(p => p.FullName).HasColumnType("varchar").HasMaxLength(255).IsRequired(true);
            builder.Property(p => p.UserName).HasColumnType("varchar").HasMaxLength(255).IsRequired(true);
            builder.Property(p => p.Password).HasColumnType("varchar").HasMaxLength(1000).IsRequired(true);
            builder.Property(p => p.Mail).HasColumnType("varchar").HasMaxLength(255).IsRequired(true);
            builder.Property(p => p.CreateDate).HasColumnType("datetime").IsRequired(true);
            builder.Property(p => p.LastLoginDate).HasColumnType("datetime").IsRequired(false);
        }
    }
}
