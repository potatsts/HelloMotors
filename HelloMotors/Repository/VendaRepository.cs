using HelloMotors.Data;
using HelloMotors.Model;
using Microsoft.EntityFrameworkCore;

namespace HelloMotors.Repository;

public class VendaRepository
{
    private AppDbContext _context;
    public VendaRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Venda>> ListarAsync()
    {
        return await _context.Vendas.ToListAsync();
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
}