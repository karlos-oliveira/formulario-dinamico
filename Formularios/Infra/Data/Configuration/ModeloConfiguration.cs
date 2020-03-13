
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;
namespace Infra.Data.Configuration
{
    public class ModeloConfiguration : IEntityTypeConfiguration<Modelo>
    {
        public void Configure(EntityTypeBuilder<Modelo> builder)
        {
            builder.ToTable("Modelo");

            builder.Property(x => x.IdModelo).IsRequired();
            builder.Property(x => x.Nome).IsRequired();
            builder.Property(x => x.IsAtivo).HasDefaultValue(true).IsRequired();

            builder.HasKey(x => x.IdModelo);
        }
    }
}
