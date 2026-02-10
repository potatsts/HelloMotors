using AutoMapper;
using Dto;
using HelloMotors.Model;
using HelloMotors.Repository;

namespace HelloMotors.Service;

public class VeiculoService
{
    private VeiculoRepository _repositorio;
    private readonly IMapper _mapper;
    public VeiculoService(VeiculoRepository repositorio, IMapper mapper)
    {
        _repositorio = repositorio;
        _mapper = mapper;
    }
    public async Task<List<Veiculo>> ListarAsync()
    {
        return await _repositorio.ListarAsync();
    }

    public async Task<Veiculo?> GetPorIdAsync(int id)
    {
        return await _repositorio.GetPorIdAsync(id);
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
    public async Task<Veiculo?> AtualizarAsync(int id, AtualizarVeiculoDto dto)
    {
        return await _repositorio.AtualizarAsync(id, dto);
    }
    public async Task<Veiculo?> DeletarAsync(int id)
    {
        return await _repositorio.DeletarAsync(id);
    }
}