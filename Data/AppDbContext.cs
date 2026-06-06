using Microsoft.EntityFrameworkCore;
using TopTechApi.Models;

namespace TopTechApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<CategoriaPeca> CategoriasPeca { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Computador> Computadores { get; set; }
        public DbSet<OrdemServico> OrdensServico { get; set; }
        public DbSet<Pagamento> Pagamentos { get; set; }
        public DbSet<Peca> Pecas { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<Tecnico> Tecnicos { get; set; }
    }
}