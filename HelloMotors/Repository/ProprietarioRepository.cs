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

    public async Task<Proprietario?> AtualizarAsync(int id, Proprietario proprietarioAtualizado)
    {
        var proprietario = await _context.Proprietarios.FindAsync(id);

        if (proprietario == null)
        {
            throw new Exception("Proprietário não encontrado.");
        }

        proprietario.Nome = proprietarioAtualizado.Nome;
        proprietario.CpfCnpj = proprietarioAtualizado.CpfCnpj;
        proprietario.Endereco = proprietarioAtualizado.Endereco;
        proprietario.Email = proprietarioAtualizado.Email;
        proprietario.Telefone = proprietarioAtualizado.Telefone;
        proprietario.DadosPessoais = proprietarioAtualizado.DadosPessoais;

        await _context.SaveChangesAsync();
        return proprietario;
    }

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