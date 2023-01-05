using ApiSqlAsp.Mappings;
using ApiSqlAsp.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiSqlAsp.DataContext
{
    public class ApiDataContext : DbContext
    {
        public ApiDataContext(DbContextOptions<ApiDataContext> options) : base(options)
        {

        }


        public DbSet<Carros> Cars { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<EstadoDeVenda> EstadoDeVendas { get; set; }
        public DbSet<Modelo> Modelos { get; set; }
        public DbSet<User> Users { get; set; }

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
