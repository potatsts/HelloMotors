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
        await _context.AddAsync(proprietario);
        await _context.SaveChangesAsync();
        return proprietario;
    }

    //atualizar
    //deletar
}