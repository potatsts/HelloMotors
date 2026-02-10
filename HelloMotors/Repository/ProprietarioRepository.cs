using HelloMotors.Data;
using HelloMotors.Model;
using Microsoft.EntityFrameworkCore;

namespace HelloMotors.Repository;

public class ProprietarioRepository
{
    private readonly AppDbContext _context;
    public ProprietarioRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Proprietario>> ListarAsync()
    {
        return await _context.Proprietarios.ToListAsync();
    }

    public async Task<Proprietario?> BuscarPorIdAsync(int id)
    {
        return await _context.Proprietarios.FirstOrDefaultAsync(v => v.IdProprietario == id);
    }

    public async Task<Proprietario> InserirAsync(Proprietario proprietario)
    {
        _context.Proprietarios.Add(proprietario);
        await _context.SaveChangesAsync();
        return proprietario;
    }

    public async Task AtualizarAsync(Proprietario proprietarioAtualizado)
    {
        _context.Proprietarios.Update(proprietarioAtualizado);
        await _context.SaveChangesAsync();
    }

    public async Task DeletarAsync(Proprietario proprietario)
    {
        _context.Proprietarios.Remove(proprietario);
        await _context.SaveChangesAsync();
    }
}