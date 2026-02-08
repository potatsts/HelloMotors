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

    //listar todos
    public async Task<List<Proprietario>> ListarAsync()
    {
        return await _context.Proprietarios.ToListAsync();
    }
    //cadastrar
    //atualizar
    //deletar
}