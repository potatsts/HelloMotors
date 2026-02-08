using Dto;
using HelloMotors.Model;
using HelloMotors.Repository;

namespace HelloMotors.Service;

public class VeiculoService
{
    private VeiculoRepository _repositorio;
    public VeiculoService(VeiculoRepository repositorio)
    {
        _repositorio = repositorio;
    }
    public async Task<List<Veiculo>> ListarAsync()
    {
        return await _repositorio.ListarAsync();
    }
    public async Task<Veiculo> InserirAsync(CadastrarVeiculoDto dto)
    {
        var veiculo = new Veiculo
        {
            Chassi = dto.Chassi,
            Modelo = dto.Modelo,
            VersaoSistema = dto.VersaoSistema,
            Ano = dto.Ano,
            Cor = dto.Cor,
            Quilometragem = dto.Quilometragem,
            Valor = dto.Valor,
            Acessorios = dto.Acessorios,
            IdProprietario = dto.IdProprietario
        };
        return await _repositorio.InserirAsync(veiculo);
    }
    public async Task<Veiculo?> AtualizarAsync(int id, AtualizarVeiculoDto dto)
    {
        var veiculoAtualizado = new Veiculo
        {
            Chassi = dto.Chassi,
            Modelo = dto.Modelo,
            VersaoSistema = dto.VersaoSistema,
            Ano = dto.Ano,
            Cor = dto.Cor,
            Quilometragem = dto.Quilometragem,
            Valor = dto.Valor,
            Acessorios = dto.Acessorios,
            IdProprietario = dto.IdProprietario
        };
        return await _repositorio.AtualizarAsync(id, veiculoAtualizado);
    }
    public async Task<Veiculo?> DeletarAsync(int id)
    {
        return await _repositorio.DeletarAsync(id);
    }
}