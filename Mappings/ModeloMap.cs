using ApiSqlAsp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiSqlAsp.Mappings
{
    public class ModeloMap : IEntityTypeConfiguration<Modelo>
    {
        public void Configure(EntityTypeBuilder<Modelo> builder)
        {
            builder.ToTable("Modelo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd().UseIdentityColumn();

            builder.Property(x => x.Nome).IsRequired().HasColumnName("Nome").HasColumnType("NVARCHAR").HasMaxLength(120);

            builder.Property(x => x.Ano).IsRequired().HasColumnName("Ano").HasColumnType("INT");

            builder.Property(x => x.Cor).IsRequired().HasColumnName("Cor").HasColumnType("NVARCHAR").HasMaxLength(40);
        }
    }
}
