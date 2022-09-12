using Confitec.Technical.Test.Domain.SystemUserModule.Permissions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Confitec.Technical.Test.Infra.Data.UserModule
{
    public class SystemUserPermissionConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.ToTable("SystemUserPermissions", "dbo");

            builder.HasKey(p => p.ID);

            builder.Property(p => p.Role).HasColumnType("varchar").HasMaxLength(255).IsRequired(true);
            builder.HasOne(p => p.SystemUser).WithMany(p => p.Permissions).HasForeignKey(p => p.SystemUserId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
