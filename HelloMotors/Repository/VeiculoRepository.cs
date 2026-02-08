using HelloMotors.Data;
using HelloMotors.Model;
using Microsoft.EntityFrameworkCore;

namespace HelloMotors.Repository;

public class VeiculoRepository
{
    private AppDbContext _context;
    public VeiculoRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<List<Veiculo>> ListarAsync()
    {
        return await _context.Veiculos.Include(v => v.Proprietario).ToListAsync();
    }
    public async Task<Veiculo> InserirAsync(Veiculo veiculo)
    {
        _context.Veiculos.Add(veiculo);
        await _context.SaveChangesAsync();
        return veiculo;
    }
    public async Task<Veiculo?> AtualizarAsync(int id, Veiculo veiculoAtualizado)
    {
        var veiculo = await _context.Veiculos.FindAsync(id);
        if (veiculo == null)
        {
            throw new Exception();
        }

        veiculo.Chassi = veiculoAtualizado.Chassi;
        veiculo.Modelo = veiculoAtualizado.Modelo;
        veiculo.VersaoSistema = veiculoAtualizado.VersaoSistema;
        veiculo.Ano = veiculoAtualizado.Ano;
        veiculo.Cor = veiculoAtualizado.Cor;
        veiculo.Quilometragem = veiculoAtualizado.Quilometragem;
        veiculo.Valor = veiculoAtualizado.Valor;
        veiculo.Acessorios = veiculoAtualizado.Acessorios;
        veiculo.IdProprietario = veiculoAtualizado.IdProprietario;

        await _context.SaveChangesAsync();
        return veiculo;
    }
    public async Task<Veiculo?> DeletarAsync(int id)
    {
        var veiculo = await _context.Veiculos.FindAsync(id);
        if (veiculo == null)
        {
            return null;
        }

        _context.Veiculos.Remove(veiculo);
        await _context.SaveChangesAsync();
        return veiculo;
    }
}