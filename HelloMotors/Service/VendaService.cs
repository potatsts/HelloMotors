using Dto;
using HelloMotors.Model;
using HelloMotors.Repository;

namespace HelloMotors.Service;

public class VendaService
{
    private VendaRepository _repositorio;
    public VendaService(VendaRepository repositorio)
    {
        _repositorio = repositorio;
    }

    public async Task<List<Venda>> ListarAsync()
    {
        return await _repositorio.ListarAsync();
    }

    public async Task<Venda?> DeletarAsync(int id)
    {
        return await _repositorio.DeletarAsync(id);
    }

    public async Task<Venda> InserirAsync(CadastrarVendaDto dto)
    {
        var venda = new Venda
        {
            IdChassi = dto.IdChassi,
            IdVendedor = dto.IdVendedor,
            DataVenda = dto.DataVenda,
            ValorFinal = dto.ValorFinal
        };
        return await _repositorio.InserirAsync(venda);
    }

    public async Task<Venda?> AtualizarAsync(int id, AtualizarVendaDto dto)
    {
        var vendaAtualizada = new Venda
        {
            IdChassi = dto.IdChassi,
            IdVendedor = dto.IdVendedor,
            DataVenda = dto.DataVenda,
            ValorFinal = dto.ValorFinal
        };
        return await _repositorio.AtualizarAsync(id, vendaAtualizada);
    }
}