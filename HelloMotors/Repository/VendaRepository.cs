using HelloMotors.Data;
using HelloMotors.Model;
using Microsoft.EntityFrameworkCore;

namespace HelloMotors.Repository;

public class VendaRepository
{
    private readonly AppDbContext _context;
    public VendaRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Venda>> ListarAsync()
    {
        return await _context.Vendas
        .Include(v => v.Veiculo).ThenInclude(v => v.Proprietario)
        .Include(v => v.Vendedor)
        .ToListAsync();
    }

    public async Task<Venda?> BuscarPorIdAsync(int id)
    {
        return await _context.Vendas.FirstOrDefaultAsync(v => v.IdVenda == id);
    }

    public async Task<IEnumerable<Venda>> ListarVendasMes(int idVendedor, int mes, int ano)
    {
        return await _context.Vendas.Where(v =>
            v.IdVendedor == idVendedor &&
            v.DataVenda.Month == mes &&
            v.DataVenda.Year == ano)
            .ToListAsync();
    }

    public async Task<Venda> InserirAsync(Venda venda)
    {
        _context.Vendas.Add(venda);
        await _context.SaveChangesAsync();
        return venda;
    }

    public async Task DeletarAsync(Venda venda)
    {
        _context.Vendas.Remove(venda);
        await _context.SaveChangesAsync();
    }
}