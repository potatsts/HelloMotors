using Microsoft.EntityFrameworkCore;
using HelloMotors.Model;

namespace HelloMotors.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Proprietario> Proprietarios { get; set; }
    public DbSet<Veiculo> Veiculos { get; set; }
    public DbSet<Venda> Vendas { get; set; }
    public DbSet<Vendedor> Vendedores { get; set; }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder
            .Properties<string>()
            .AreUnicode(false);
    }

}