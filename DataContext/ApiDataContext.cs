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

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=localhost,1433; Database=Api; trustServerCertificate= true; User Id=sa; Password=123456789");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   //Mapeamento do entity
            modelBuilder.ApplyConfiguration(new CarrosMap());
            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new EstadoDeVendaMap());
            modelBuilder.ApplyConfiguration(new ModeloMap());
        }
    }
}
