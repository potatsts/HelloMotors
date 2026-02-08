using HelloMotors.Data;
using HelloMotors.Model;
using Microsoft.EntityFrameworkCore;

namespace HelloMotors.Repository;

public class ProprietarioRepository
{
    private AppDbContext _context;
    public ProprietarioRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Proprietario>> ListarAsync()
    {
        return await _context.Proprietarios.ToListAsync();
    }

    public async Task<Proprietario> CriarAsync(Proprietario proprietario)
    {
        _context.Proprietarios.Add(proprietario);
        await _context.SaveChangesAsync();
        return proprietario;
    }

    //atualizar

    public async Task<Proprietario?> DeletarAsync(int id)
    {
        var proprietario = await _context.Proprietarios.FindAsync(id);
        if (proprietario == null)
        {
            return null;
        }

        _context.Proprietarios.Remove(proprietario);
        await _context.SaveChangesAsync();
        return proprietario;
    }
}