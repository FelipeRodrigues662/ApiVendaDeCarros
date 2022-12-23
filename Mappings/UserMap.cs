using ApiSqlAsp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiSqlAsp.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd().UseIdentityColumn();

            builder.Property(x=> x.UserNames).IsRequired().HasColumnName("UserNames").HasColumnType("NVARCHAR").HasMaxLength(64);

            builder.Property(x => x.Password).IsRequired().HasColumnName("Password").HasColumnType("NVARCHAR").HasMaxLength(64);

            builder.Property(x => x.Autorizacao).IsRequired().HasColumnName("Autorizacao").HasColumnType("NVARCHAR").HasMaxLength(64);
        }
    }
}
