using Microsoft.AspNetCore.Mvc;
using HelloMotors.Model;
using HelloMotors.Service;
using Dto;
using Swashbuckle.AspNetCore.Annotations;

namespace HelloMotors.Controller;

[ApiController]
[Route("api/[controller]")]
public class VendedorController : ControllerBase
{
    private VendedorService _servico;

    public VendedorController(VendedorService servico)
    {
        _servico = servico;
    }

    [SwaggerOperation(Summary = "Lista os vendedores")] 
    [HttpGet]
    public async Task<ActionResult<List<Vendedor>>> ListarAsync()
    {
        List<Vendedor> vendedores = await _servico.ListarAsync();
        return Ok(vendedores);
    }

    [SwaggerOperation(Summary = "Busca vendedor por Id")] 
    [HttpGet("{id}")]
    public async Task<ActionResult<Vendedor>> GetPorId(int id)
    {
        var venda = await _servico.BuscarPorIdAsync(id);
        return Ok(venda);
    }

    [SwaggerOperation(Summary = "Ver Comissão Por Id do vendedor")] 
    [HttpGet("{idVendedor}/{mes}/{ano}")]
    public async Task<ActionResult<ComissaoDto>> CalcularComissao(int idVendedor, int mes, int ano)
    {

        var dto = await _servico.CalcularComissao(idVendedor, mes, ano);
        return Ok(dto);
    }

    [SwaggerOperation(Summary = "Cria o registro de um novo vendedor")]
    [HttpPost]
    public async Task<ActionResult<Vendedor>> CriarAsync(CadastrarVendedorDto dto)
    {
        var vendedor = await _servico.InserirAsync(dto);
        return Created("", vendedor);
    }

    [SwaggerOperation(Summary = "Atualiza os dados de um vendedor")] 
    [HttpPut("{id}")]
    public async Task<ActionResult> AtualizarAsync(int id, AtualizarVendedorDto dto)
    {
        await _servico.AtualizarAsync(id, dto);
        return NoContent();
    }

    [SwaggerOperation(Summary = "Deleta o registro de um vendedor")] 
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeletarAsync(int id)
    {
        await _servico.DeletarAsync(id);
        return NoContent();
    }

}