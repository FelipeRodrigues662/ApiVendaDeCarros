using ApiSqlAsp.Mappings;
using ApiSqlAsp.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiSqlAsp.DataContext
{
    public class ApiDataContext : DbContext
    {
        public DbSet<Carros> Cars { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<EstadoDeVenda> EstadoDeVendas { get; set; }
        public DbSet<Modelo> Modelos { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=tcp:datafelipeestudo.database.windows.net,1433;Initial Catalog=Api;Persist Security Info=False;User ID=feliperodrigues;Password=@5432109876F;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   //Mapeamento do entity
            modelBuilder.ApplyConfiguration(new CarrosMap());
            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new EstadoDeVendaMap());
            modelBuilder.ApplyConfiguration(new ModeloMap());
            modelBuilder.ApplyConfiguration(new UserMap());
        }
    }
}
