using HelloMotors.Model;
using HelloMotors.Repository;
using Dto;
using AutoMapper;

namespace HelloMotors.Service;

public class ProprietarioService
{
    private readonly ProprietarioRepository _repositorio;
    private readonly IMapper _mapper;
    public ProprietarioService(ProprietarioRepository repositorio, IMapper mapper)
    {
        _repositorio = repositorio;
        _mapper = mapper;
    }

    public async Task<List<Proprietario>> ListarAsync()
    {
        return await _repositorio.ListarAsync();
    }

    public async Task<Proprietario> BuscarPorIdAsync(int id)
    {
        return await _repositorio.BuscarPorIdAsync(id) ?? throw new InvalidOperationException();
    }

    public async Task<Proprietario> CriarAsync(CadastrarProprietarioDto dto)
    {
        var proprietario = _mapper.Map<Proprietario>(dto);
        return await _repositorio.InserirAsync(proprietario);
    }

    public async Task AtualizarAsync(int id, AtualizarProprietarioDto dto)
    {
        var proprietario = await _repositorio.BuscarPorIdAsync(id) ?? throw new InvalidOperationException();
        _mapper.Map(dto, proprietario);
        await _repositorio.AtualizarAsync(proprietario);
    }

    public async Task DeletarAsync(int id)
    {
        var proprietario = await _repositorio.BuscarPorIdAsync(id) ?? throw new InvalidOperationException();
        await _repositorio.DeletarAsync(proprietario);
    }
}