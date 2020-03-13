
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;
namespace Infra.Data.Configuration
{
    public class TipoAtributoConfiguration : IEntityTypeConfiguration<TipoAtributo>
    {
        public void Configure(EntityTypeBuilder<TipoAtributo> builder)
        {
            builder.ToTable("TipoAtributo");

            builder.Property(x => x.IdTipoAtributo).IsRequired();
            //builder.Property(x => x.IdConta);
            builder.Property(x => x.IsAtivo).HasDefaultValue(true).IsRequired();
            builder.Property(x => x.Nome).IsRequired();
            builder.Property(x => x.Descricao).IsRequired();

            builder.HasKey(x => x.IdTipoAtributo);
        }
    }
}
