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
        return await _servico.ListarAsync();
    }

    [SwaggerOperation(Summary = "Cria o registro de um novo vendedor")]
    [HttpPost]
    public async Task<ActionResult<Vendedor>> CriarAsync(CadastrarVendedorDto dto)
    {
        var vendedor = await _servico.CriarAsync(dto);
        return Ok(vendedor);
    }

    [SwaggerOperation(Summary = "Atualiza os dados de um vendedor")]
    [HttpPut("{id}")]
    public async Task<ActionResult<Vendedor>> AtualizarAsync(int id, [FromBody] AtualizarVendedorDto dto)
    {
        var vendedor = await _servico.AtualizarAsync(id, dto);
        return Ok(vendedor);
    }

    [SwaggerOperation(Summary = "Deleta o registro de um vendedor")]
    [HttpDelete("{id}")]
    public async Task<ActionResult<Vendedor>> DeletarAsync(int id)
    {
        var vendedor = await _servico.DeletarAsync(id);
        if (vendedor == null)
        {
            return NotFound("Vendedor não encontrado");
        }
        return Ok(vendedor);
    }

    [SwaggerOperation(Summary = "Ver Comissão Por Id do vendedor")]
    [HttpGet("{idVendedor}/{mes}/{ano}")]
    public async Task<ActionResult<ComissaoDto>> CalcularComissao(int idVendedor, int mes, int ano)
    {
        var dto = await _servico.CalcularComissao(idVendedor, mes, ano);
        if (dto == null)
        {
            return NotFound();
        }
        return Ok(dto);
    }

}