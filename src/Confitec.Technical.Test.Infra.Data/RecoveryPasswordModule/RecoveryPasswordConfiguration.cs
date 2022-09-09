using Confitec.Technical.Test.Domain.RecoveryPasswordModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Confitec.Technical.Test.Infra.Data.RecoveryPasswordModule
{
    public class RecoveryPasswordConfiguration : IEntityTypeConfiguration<RecoveryPassword>
    {
        public void Configure(EntityTypeBuilder<RecoveryPassword> builder)
        {
            builder.ToTable("RecoveryPassword", "dbo");
            
            builder.HasKey(p => p.ID);

            builder.Property(p => p.Code).HasColumnType("varchar").HasMaxLength(50).IsRequired(true);
            builder.Property(p => p.IsUsed).HasColumnType("bit").IsRequired(true);
            builder.Property(p => p.ExpirationDate).HasColumnType("datetime").IsRequired(true);

            builder.Property(p => p.SystemUserID).HasColumnType("int").IsRequired(true);
            builder.HasOne(p => p.SystemUser).WithMany(p => p.RecoveryPasswords).HasForeignKey(p => p.SystemUserID).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
