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

    [SwaggerOperation(Summary = "Lista os vendedores")] //feito
    [HttpGet]
    public async Task<ActionResult<List<Vendedor>>> ListarAsync()
    {
        try
        {
            List<Vendedor> vendedores = await _servico.ListarAsync();
            return Ok(vendedores);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    [SwaggerOperation(Summary = "Cria o registro de um novo vendedor")] //feito
    [HttpPost]
    public async Task<ActionResult<Vendedor>> CriarAsync(CadastrarVendedorDto dto)
    {
        try
        {
            var vendedor = await _servico.CriarAsync(dto);
            return Created("", vendedor);  
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        
    }

    [SwaggerOperation(Summary = "Atualiza os dados de um vendedor")] //feito
    [HttpPut("{id}")]
    public async Task<ActionResult<Vendedor>> AtualizarAsync(int id, [FromBody] AtualizarVendedorDto dto)
    {
        try
        {
            var vendedor = await _servico.AtualizarAsync(id, dto);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [SwaggerOperation(Summary = "Deleta o registro de um vendedor")] //Rever===========================================================
    [HttpDelete("{id}")]
    public async Task<ActionResult<Vendedor>> DeletarAsync(int id)
    {   
        try
        {
            var vendedor = await _servico.DeletarAsync(id);
            if (vendedor == null)
            {
                return NotFound("Vendedor não encontrado");
            }
            return NoContent();          
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    [SwaggerOperation(Summary = "Ver Comissão Por Id do vendedor")] //feito
    [HttpGet("{idVendedor}/{mes}/{ano}")]
    public async Task<ActionResult<ComissaoDto>> CalcularComissao(int idVendedor, int mes, int ano)
    {   
        try
        {
           var dto = await _servico.CalcularComissao(idVendedor, mes, ano);
            if (dto == null)
            {
                return NotFound();
            }
            return Ok(dto); 
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
        
    }

}