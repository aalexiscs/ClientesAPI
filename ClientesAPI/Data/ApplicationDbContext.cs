using Microsoft.EntityFrameworkCore;

namespace ClientesAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<ClientesAPI.Models.Clientes> Clientes => Set<ClientesAPI.Models.Clientes>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ClientesAPI.Models.Clientes>().HasKey(c => c.ClienteID);
            modelBuilder.Entity<ClientesAPI.Models.Clientes>().Property(c => c.Nombre).IsRequired();
            modelBuilder.Entity<ClientesAPI.Models.Clientes>().Property(c => c.Apellido).IsRequired();
            modelBuilder.Entity<ClientesAPI.Models.Clientes>().Property(c => c.Email).IsRequired(false);
        }
    }
}
