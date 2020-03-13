
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;
namespace Infra.Data.Configuration
{
    public class AtributoConfiguration : IEntityTypeConfiguration<Atributo>
    {
        public void Configure(EntityTypeBuilder<Atributo> builder)
        {
            builder.ToTable("Atributo");

            builder.Property(x => x.IdAtributo).IsRequired();
            builder.Property(x => x.Descricao).IsRequired();
            builder.Property(x => x.IdConta);
            builder.Property(x => x.IdTipoAtributo).IsRequired();
            builder.Property(x => x.IsAtivo).HasDefaultValue(true).IsRequired();
            builder.Property(x => x.Label);
            builder.Property(x => x.NomeCampo);
            builder.Property(x => x.TamanhoMaximo);

            builder.HasKey(x => x.IdAtributo);
        }
    }
}
