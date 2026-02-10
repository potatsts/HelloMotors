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

    public async Task<Venda> BuscarPorIdAsync(int id)
    {
        return await _vendaRepositorio.BuscarPorIdAsync(id) ?? throw new InvalidOperationException();
    }

    public async Task<Venda?> InserirAsync(CadastrarVendaDto dto)
    {
        var veiculo = await _veiculoRepositorio.BuscarPorIdAsync(dto.IdChassi) ?? throw new InvalidOperationException();

        veiculo.IdProprietario = dto.IdProprietario;
        var venda = _mapper.Map<Venda>(dto);

        return await _vendaRepositorio.InserirAsync(venda);
    }

    public async Task DeletarAsync(int id)
    {
        var venda = await _vendaRepositorio.BuscarPorIdAsync(id) ?? throw new InvalidOperationException();
        await _vendaRepositorio.DeletarAsync(venda);
    }
}