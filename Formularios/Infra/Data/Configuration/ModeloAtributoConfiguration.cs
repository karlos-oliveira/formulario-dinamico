
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;
namespace Infra.Data.Configuration
{
    public class ModeloAtributoConfiguration : IEntityTypeConfiguration<ModeloAtributo>
    {
        public void Configure(EntityTypeBuilder<ModeloAtributo> builder)
        {
            builder.ToTable("ModeloAtributo");

            builder.Property(x => x.IdModeloAtributo).IsRequired();
            builder.Property(x => x.IdAtributo).IsRequired();
            builder.Property(x => x.IdModelo).IsRequired();
            builder.Property(x => x.Ordem);
            builder.Property(x => x.Versao).IsRequired(); ;
            builder.Property(x => x.Obrigatorio).HasDefaultValue(false).IsRequired(); 
            builder.Property(x => x.MultiplaEscolha).HasDefaultValue(false).IsRequired();
            builder.Property(x => x.Opcoes);

            builder.HasKey(x => x.IdModeloAtributo);
        }
    }
}
