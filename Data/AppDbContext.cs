using Microsoft.EntityFrameworkCore;
using TopTechApi.Models;

namespace TopTechApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Computador> Computadores { get; set; }
        public DbSet<Tecnico> Tecnicos { get; set; }
        public DbSet<OrdemServico> OrdensServicos { get; set; }
        public DbSet<Peca> Pecas { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<Pagamento> Pagamentos { get; set; }
        public DbSet<CategoriaPeca> CategoriasPecas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoriaPeca>().HasData(
                new CategoriaPeca { Id = 1, Nome = "Placa-Mãe" },
                new CategoriaPeca { Id = 2, Nome = "Memória RAM" }
            );

            modelBuilder.Entity<Tecnico>().HasData(
                new Tecnico { Id = 1, Nome = "Carlos Silva", Especialidade = "Hardware" },
                new Tecnico { Id = 2, Nome = "Ana Souza", Especialidade = "Redes e Software" }
            );
        }
    }
}
