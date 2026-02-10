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

    public async Task<Venda?> DeletarAsync(int id)
    {
        var venda = await _context.Vendas.FindAsync(id);
        if (venda == null)
        {
            return null;
        }

        _context.Vendas.Remove(venda);
        await _context.SaveChangesAsync();
        return venda;
    }

    public async Task<Venda> InserirAsync(Venda venda)
    {
        _context.Vendas.Add(venda);
        await _context.SaveChangesAsync();
        return venda;
    }

    // public async Task<Venda?> AtualizarAsync(int id, Venda vendaAtualizada)
    // {
    //     var venda = await _context.Vendas.FindAsync(id);
    //     if (venda == null)
    //     {
    //         throw new Exception();
    //     }

    //     venda.IdChassi = vendaAtualizada.IdChassi;
    //     venda.IdVendedor = vendaAtualizada.IdVendedor;
    //     venda.DataVenda = vendaAtualizada.DataVenda;
    //     venda.ValorFinal = vendaAtualizada.ValorFinal;

    //     await _context.SaveChangesAsync();
    //     return venda;
    // }

    public async Task<IEnumerable<Venda>> GetVendasMes(int idVendedor, int mes, int ano)
    {
        return await _context.Vendas.Where(v =>
            v.IdVendedor == idVendedor &&
            v.DataVenda.Month == mes &&
            v.DataVenda.Year == ano)
            .ToListAsync();
    }
}