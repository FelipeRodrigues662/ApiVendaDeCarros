using ApiSqlAsp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiSqlAsp.Mappings
{
    public class CarrosMap : IEntityTypeConfiguration<Carros>
    {
        public void Configure(EntityTypeBuilder<Carros> builder)
        {
            builder.ToTable("Carros");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd().UseIdentityColumn();

            builder.Property(x => x.ModeloId).IsRequired().HasColumnName("ModeloId").HasColumnType("INT");

            builder.Property(x => x.Valor).IsRequired().HasColumnName("Valor").HasColumnType("MONEY");

            builder.Property(X => X.EstadoDeVendaId).IsRequired().HasColumnName("EstadoDeVendaId").HasColumnType("INT");
        }
    }
}
