using AutoMapper;
using Dto;
using HelloMotors.Model;
using HelloMotors.Repository;

namespace HelloMotors.Service;

public class VeiculoService
{
    private readonly VeiculoRepository _repositorio;
    private readonly IMapper _mapper;
    public VeiculoService(VeiculoRepository repositorio, IMapper mapper)
    {
        _repositorio = repositorio;
        _mapper = mapper;
    }
    public async Task<List<EstoqueVeiculoDto>> ListarAsync()
    {
        var veiculos = await _repositorio.ListarAsync();
        var veiculoDtops = _mapper.Map<List<EstoqueVeiculoDto>>(veiculos);
        return veiculoDtops;
    }

    public async Task<Veiculo> BuscarPorIdAsync(int id)
    {
        return await _repositorio.BuscarPorIdAsync(id) ?? throw new KeyNotFoundException($"Veículo com id {id} não encontrado!");
    }

    public async Task<List<Veiculo>> ListarPorQuilometragemAsync(string versaoSistema)
    {
        return await _repositorio.ListarPorQuilometragemAsync(versaoSistema);
    }

    public async Task<Veiculo> InserirAsync(CadastrarVeiculoDto dto)
    {
        var veiculo = _mapper.Map<Veiculo>(dto);
        return await _repositorio.InserirAsync(veiculo);
    }
    public async Task AtualizarAsync(int id, AtualizarVeiculoDto dto)
    {
        var veiculo = await _repositorio.BuscarPorIdAsync(id) ?? throw new KeyNotFoundException($"Veículo com id {id} não encontrado!");
        _mapper.Map(dto, veiculo);
        await _repositorio.AtualizarAsync(veiculo);
    }
    public async Task DeletarAsync(int id)
    {
        var veiculo = await _repositorio.BuscarPorIdAsync(id) ?? throw new KeyNotFoundException($"Veículo com id {id} não encontrado!");
        await _repositorio.DeletarAsync(veiculo);
    }
}