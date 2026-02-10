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

    public async Task<Vendedor?> BuscarPorIdAsync(int id)
    {
        return await _context.Vendedores.FirstOrDefaultAsync(v => v.IdVendedor == id);
    }

    public async Task<Vendedor> InserirAsync(Vendedor vendedor)
    {
        _context.Vendedores.Add(vendedor);
        await _context.SaveChangesAsync();
        return vendedor;
    }

    public async Task AtualizarAsync(Vendedor vendedorAtualizado)
    {
        _context.Vendedores.Update(vendedorAtualizado);
        await _context.SaveChangesAsync();
    }

    public async Task DeletarAsync(Vendedor vendedor)
    {
        _context.Vendedores.Remove(vendedor);
        await _context.SaveChangesAsync();
    }
}