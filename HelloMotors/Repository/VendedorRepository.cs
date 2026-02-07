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

    //metodos incluir, alterar, excluir
}