using ApiSqlAsp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiSqlAsp.Mappings
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd().UseIdentityColumn();

            builder.Property(x => x.Nome).IsRequired().HasColumnName("Nome").HasColumnType("NVARCHAR").HasMaxLength(120);

            builder.Property(x => x.Telefone).IsRequired().HasColumnName("Telefone").HasColumnType("INT");
        }
    }
}
