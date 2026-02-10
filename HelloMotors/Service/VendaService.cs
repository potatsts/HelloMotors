using AutoMapper;
using Dto;
using HelloMotors.Model;
using HelloMotors.Repository;

namespace HelloMotors.Service;

public class VendaService
{
    private readonly VendaRepository _vendaRepositorio;
    private readonly VeiculoRepository _veiculoRepositorio;
    private IMapper _mapper;
    public VendaService(VendaRepository vendaRepositorio, VeiculoRepository veiculoRepositorio, IMapper mapper)
    {
        _vendaRepositorio = vendaRepositorio;
        _veiculoRepositorio = veiculoRepositorio;
        _mapper = mapper;
    }

    public async Task<List<Venda>> ListarAsync()
    {
        return await _vendaRepositorio.ListarAsync();
    }

    public async Task<Venda?> DeletarAsync(int id)
    {
        return await _vendaRepositorio.DeletarAsync(id);
    }

    public async Task<Venda?> InserirAsync(CadastrarVendaDto dto)
    {
        var veiculo = await _veiculoRepositorio.GetPorIdAsync(dto.IdChassi);
        if (veiculo == null)
        {
            return null;
        }

        veiculo.IdProprietario = dto.IdProprietario;
        var venda = _mapper.Map<Venda>(dto);

        return await _vendaRepositorio.InserirAsync(venda);
    }

    // public async Task<Venda?> AtualizarAsync(int id, AtualizarVendaDto dto)
    // {
    //     var vendaAtualizada = new Venda
    //     {
    //         IdChassi = dto.IdChassi,
    //         IdVendedor = dto.IdVendedor,
    //         DataVenda = dto.DataVenda,
    //         ValorFinal = dto.ValorFinal
    //     };
    //     return await _vendaRepositorio.AtualizarAsync(id, vendaAtualizada);
    // }
}