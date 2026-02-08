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

    public async Task<Vendedor> CriarAsync(Vendedor vendedor)
    {
        _context.Vendedores.Add(vendedor); //adiciona o vendedor ao contexto
        await _context.SaveChangesAsync(); //salva as alterações no banco de dados
        return vendedor;
    }

    //metodos incluir, alterar, excluir
}