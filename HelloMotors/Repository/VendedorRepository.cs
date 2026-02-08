using HelloMotors.Data;
using HelloMotors.Model;
using Microsoft.AspNetCore.Http.HttpResults;
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

    public async Task<Vendedor> DeletarAsync(int id)
    {
        var vendedor = await _context.Vendedores.FindAsync(id); //encontra o vendedor pelo id
        if (vendedor == null)
        {
            return null; //retorna null se o vendedor não for encontrado
        }

        _context.Vendedores.Remove(vendedor); //remove o vendedor do contexto
        await _context.SaveChangesAsync(); //salva as alterações no banco de dados
        return vendedor; //retorna o vendedor deletado
    }

    //metodos incluir, alterar, excluir
}