using HelloMotors.Model;
using HelloMotors.Repository;
using Dto;

namespace HelloMotors.Service;

public class VendedorService
{
    private readonly VendedorRepository _repositorio;

    public VendedorService(VendedorRepository repositorio)
    {
        _repositorio = repositorio;
    }

    public async Task<List<Vendedor>> ListarAsync()
    {
        return await _repositorio.ListarAsync();
    }

    public async Task<Vendedor> CriarAsync(CadastrarVendedorDto dto) 
    {
        var vendedor = new Vendedor //mapeamento do dto para o modelo
        {   
            Nome = dto.Nome,
            SalarioBase = dto.SalarioBase,
        };

        return await _repositorio.CriarAsync(vendedor); //método do repositório para criar o vendedor no banco de dados
    }
}