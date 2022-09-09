using Confitec.Technical.Test.Domain.ParametersModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Confitec.Technical.Test.Infra.Data.ParametersModule
{
    public class ParameterConfiguration : IEntityTypeConfiguration<Parameter>
    {
        public void Configure(EntityTypeBuilder<Parameter> builder)
        {
            builder.ToTable("Parameters", "dbo");

            builder.HasKey(p => p.ID);

            builder.Property(p => p.Key).HasColumnType("varchar").HasMaxLength(255).IsRequired(true);
            builder.Property(p => p.Value).HasColumnType("varchar").HasMaxLength(255).IsRequired(true);
            builder.Property(p => p.LastDateUpdated).HasColumnType("datetime").HasMaxLength(255).IsRequired(true);
        }
    }
}
