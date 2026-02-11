using HelloMotors.Model;
using HelloMotors.Repository;
using Dto;
using AutoMapper;

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

    public async Task<Vendedor> BuscarPorIdAsync(int id)
    {
        return await _vendedorRepositorio.BuscarPorIdAsync(id) ?? throw new KeyNotFoundException($"Vendedor com id {id} não encontrado!");
    }

    public async Task<Vendedor> InserirAsync(CadastrarVendedorDto dto)
    {
        var vendedor = new Vendedor
        {
            Nome = dto.Nome,
            SalarioBase = dto.SalarioBase,
        };

        return await _vendedorRepositorio.InserirAsync(vendedor);
    }

    public async Task AtualizarAsync(int id, AtualizarVendedorDto dto)
    {
        var vendedor = await _vendedorRepositorio.BuscarPorIdAsync(id) ?? throw new KeyNotFoundException($"Vendedor com id {id} não encontrado!");

        vendedor.Nome = dto.Nome;
        vendedor.SalarioBase = dto.SalarioBase;

        await _vendedorRepositorio.AtualizarAsync(vendedor);
    }

    public async Task DeletarAsync(int id)
    {
        var vendedor = await _vendedorRepositorio.BuscarPorIdAsync(id) ?? throw new KeyNotFoundException($"Vendedor com id {id} não encontrado!");
        await _vendedorRepositorio.DeletarAsync(vendedor);
    }

    public async Task<ComissaoDto?> CalcularComissao(int id, int mes, int ano)
    {
        if (mes <= 0 || mes > 12)
        {
            throw new ArgumentException("Mês inválido");
        }

        if (ano < 2026 || ano > DateTime.Now.Year)
        {
            throw new ArgumentException("Ano inválido");
        }

        var vendedor = await _vendedorRepositorio.BuscarPorIdAsync(id);
        if (vendedor == null)
        {
            throw new KeyNotFoundException($"Vendedor com id {id} não encontrado");
        }

        var valorVendas = await _vendaRepositorio.ListarVendasMes(id, mes, ano);

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
