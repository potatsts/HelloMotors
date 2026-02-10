using AutoMapper;
using Dto;
using HelloMotors.Data;
using HelloMotors.Model;
using Microsoft.EntityFrameworkCore;

namespace HelloMotors.Repository;

public class VeiculoRepository
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;
    public VeiculoRepository(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Veiculo?> GetPorIdAsync(int id)
    {
        return await _context.Veiculos.Include(v => v.Proprietario).FirstOrDefaultAsync(v => v.IdChassi == id);
    }
    public async Task<List<Veiculo>> ListarAsync()
    {
        return await _context.Veiculos.Where(v => v.IdProprietario == null).ToListAsync();
    }

    public async Task<List<Veiculo>> ListarPorQuilometragemAsync(string versaoSistema)
    {
        return await _context.Veiculos.Include(v => v.Proprietario).Where(v => v.VersaoSistema == versaoSistema).OrderBy(v => v.Quilometragem).ToListAsync();
    }
    public async Task<Veiculo> InserirAsync(Veiculo veiculo)
    {
        _context.Veiculos.Add(veiculo);
        await _context.SaveChangesAsync();
        return veiculo;
    }
    public async Task<Veiculo?> AtualizarAsync(int id, AtualizarVeiculoDto dto)
    {
        var veiculo = await _context.Veiculos.FindAsync(id);
        if (veiculo == null)
        {
            return null;
        }

        _mapper.Map(dto, veiculo);

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