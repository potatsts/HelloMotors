using HelloMotors.Data;
using HelloMotors.Model;
using Microsoft.EntityFrameworkCore;

namespace HelloMotors.Repository;

public class VeiculoRepository
{
    private readonly AppDbContext _context;
    public VeiculoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Veiculo>> ListarAsync()
    {
        return await _context.Veiculos.Where(v => v.IdProprietario == null).ToListAsync();
    }

    public async Task<List<Veiculo>> ListarPorQuilometragemAsync(string versaoSistema)
    {
        return await _context.Veiculos.Include(v => v.Proprietario).Where(v => v.VersaoSistema == versaoSistema).OrderBy(v => v.Quilometragem).ToListAsync();
    }

    public async Task<Veiculo?> BuscarPorIdAsync(int id)
    {
        return await _context.Veiculos.Include(v => v.Proprietario).FirstOrDefaultAsync(v => v.IdVeiculo == id);
    }

    public async Task<Veiculo> InserirAsync(Veiculo veiculo)
    {
        _context.Veiculos.Add(veiculo);
        await _context.SaveChangesAsync();
        return veiculo;
    }

    public async Task AtualizarAsync(Veiculo veiculoAtualizado)
    {
        _context.Veiculos.Update(veiculoAtualizado);
        await _context.SaveChangesAsync();
    }

    public async Task DeletarAsync(Veiculo veiculo)
    {
        _context.Veiculos.Remove(veiculo);
        await _context.SaveChangesAsync();
    }
}