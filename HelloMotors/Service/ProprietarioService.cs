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
    public async Task<Proprietario> CriarAsync(CadastrarProprietarioDto dto)
    {
        var proprietario = _mapper.Map<Proprietario>(dto);
        return await _repositorio.CriarAsync(proprietario);
    }
    public async Task<Proprietario?> AtualizarAsync(int id, AtualizarProprietarioDto dto)
    {
        return await _repositorio.AtualizarAsync(id, dto);
    }
    public async Task<Proprietario?> DeletarAsync(int id)
    {
        return await _repositorio.DeletarAsync(id);
    }
}