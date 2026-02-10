using HelloMotors.Model;
using HelloMotors.Repository;
using Dto;
using System.Reflection.Metadata.Ecma335;
using AutoMapper;
using HelloMotors.Migrations;

namespace HelloMotors.Service;

public class VendedorService
{
    private readonly VendedorRepository _vendedorRepositorio;
    private readonly VendaRepository _vendaRepositorio;
    private readonly IMapper _mapper;

    public VendedorService(VendedorRepository vendedorRepositorio, VendaRepository vendaRepositorio, IMapper mapper)
    {
        _vendedorRepositorio = vendedorRepositorio;
        _vendaRepositorio = vendaRepositorio;
        _mapper = mapper;
    }

    public async Task<List<Vendedor>> ListarAsync()
    {
        return await _vendedorRepositorio.ListarAsync();
    }

    public async Task<Vendedor> CriarAsync(CadastrarVendedorDto dto) 
    {
        var vendedor = new Vendedor //mapeamento do dto para o modelo
        {   
            Nome = dto.Nome,
            SalarioBase = dto.SalarioBase,
        };

        return await _vendedorRepositorio.CriarAsync(vendedor); //método do repositório para criar o vendedor no banco de dados
    }

    public async Task<Vendedor?> AtualizarAsync(int id, AtualizarVendedorDto dto)
    {
        var vendedorAtualizado = new Vendedor //mapeamento do dto para o modelo
        {
            Nome = dto.Nome,
            SalarioBase = dto.SalarioBase,
        };
        return await _vendedorRepositorio.AtualizarAsync(id, vendedorAtualizado); //método do repositório para atualizar o vendedor no banco de dados
    }

    public async Task<Vendedor?> DeletarAsync(int id)
    {
        return await _vendedorRepositorio.DeletarAsync(id); //método do repositório para deletar o vendedor do banco de dados
    }

    public async Task<ComissaoDto?> CalcularComissao(int id, int mes, int ano)
    {
        var vendedor = await _vendedorRepositorio.GetPorId(id);
        if (vendedor == null)
        {
            return null;
        }

        var valorVendas = await _vendaRepositorio.GetVendasMes(id, mes, ano);
        decimal percComissao = 0.01m;
        decimal totalVendido = valorVendas.Sum(v => v.ValorFinal);
        decimal totalComissao = totalVendido * percComissao;
        decimal salarioFinal = vendedor.SalarioBase + totalComissao;

        return new ComissaoDto
        {
          IdVendedor = vendedor.IdVendedor,
          Nome = vendedor.Nome,
          TotalVendasMes = totalVendido,
          SalarioBase = vendedor.SalarioBase,
          TotalComissao = totalComissao,
          SalarioFinal = salarioFinal
        };
    }
}
