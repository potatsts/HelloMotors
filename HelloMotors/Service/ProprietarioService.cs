using HelloMotors.Model;
using HelloMotors.Repository;
using Dto;

namespace HelloMotors.Service;

public class ProprietarioService
{
    private ProprietarioRepository _repositorio;
    public ProprietarioService(ProprietarioRepository repositorio)
    {
        _repositorio = repositorio;
    }

    public async Task<List<Proprietario>> ListarAsync()
    {
        return await _repositorio.ListarAsync();
    }
    public async Task<Proprietario> CriarAsync(CadastrarProprietarioDto dto)
    {
        var proprietario = new Proprietario
        {
            Nome = dto.Nome,
            CpfCnpj = dto.CpfCnpj,
            Endereco = dto.Endereco,
            Email = dto.Email,
            Telefone = dto.Telefone,
            DadosPessoais = dto.DadosPessoais
        };
        return await _repositorio.CriarAsync(proprietario);
    }
    //atualizar
    //deletar
}