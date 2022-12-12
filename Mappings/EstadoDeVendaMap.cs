using ApiSqlAsp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiSqlAsp.Mappings
{
    public class EstadoDeVendaMap : IEntityTypeConfiguration<EstadoDeVenda>
    {
        public void Configure(EntityTypeBuilder<EstadoDeVenda> builder)
        {
            builder.ToTable("EstadoDeVenda");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd().UseIdentityColumn();

            builder.Property(x => x.Vendido).IsRequired().HasColumnName("Vendido").HasColumnType("BIT").HasDefaultValue(false);

            builder.Property(x => x.ClienteId).IsRequired().HasColumnName("ClienteId").HasColumnType("INT");

        }
    }
}
