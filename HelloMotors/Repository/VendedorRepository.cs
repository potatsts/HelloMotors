using HelloMotors.Data;
using HelloMotors.Model;
using Microsoft.EntityFrameworkCore;

namespace HelloMotors.Repository;

public class VendedorRepository
{
    private readonly AppDbContext _context;

    public VendedorRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Vendedor>> ListarAsync()
    {
        return await _context.Vendedores.ToListAsync();
    }

    public async Task<Vendedor?> GetPorId(int id)
    {
        return await _context.Vendedores.FirstOrDefaultAsync(v => v.IdVendedor == id);
    }

    public async Task<Vendedor> CriarAsync(Vendedor vendedor)
    {
        _context.Vendedores.Add(vendedor);
        await _context.SaveChangesAsync();
        return vendedor;
    }

    public async Task<Vendedor?> AtualizarAsync(int id, Vendedor vendedorAtualizado)
    {
        var vendedor = await _context.Vendedores.FindAsync(id);
        if (vendedor == null) return null;

        vendedor.Nome = vendedorAtualizado.Nome;
        vendedor.SalarioBase = vendedorAtualizado.SalarioBase;

        await _context.SaveChangesAsync();
        return vendedor;
    }

    public async Task<Vendedor?> DeletarAsync(int id)
    {
        var vendedor = await _context.Vendedores.FindAsync(id);
        if (vendedor == null)
        {
            return null;
        }

        _context.Vendedores.Remove(vendedor);
        await _context.SaveChangesAsync();
        return vendedor;
    }
}