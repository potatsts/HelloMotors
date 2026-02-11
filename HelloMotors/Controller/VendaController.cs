using Microsoft.AspNetCore.Mvc;
using HelloMotors.Model;
using HelloMotors.Service;
using Dto;
using Swashbuckle.AspNetCore.Annotations;

namespace HelloMotors.Controller;

[ApiController]
[Route("api/[controller]")]
public class VendaController : ControllerBase
{
    private VendaService _servico;

    public VendaController(VendaService servico)
    {
        _servico = servico;
    }

    [SwaggerOperation(Summary = "Lista as vendas realizadas")] 
    [HttpGet]
    public async Task<ActionResult<List<Venda>>> ListarAsync()
    {
        try
        {
            List<Venda> vendas = await _servico.ListarAsync();
            return Ok(vendas);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }

    }

    [SwaggerOperation(Summary = "Busca venda por Id")] 
    [HttpGet("{id}")]
    public async Task<ActionResult<Venda>> GetPorId(int id)
    {
        try
        {
            var venda = await _servico.BuscarPorIdAsync(id);
            return Ok(venda);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    [SwaggerOperation(Summary = "Registra uma nova venda")] 
    [HttpPost]
    public async Task<ActionResult<Venda>> InserirAsync(CadastrarVendaDto dto)
    {
        try
        {
            var venda = await _servico.InserirAsync(dto);
            return Created("", venda);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }


    [SwaggerOperation(Summary = "Deleta o registro de uma venda")] 
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeletarAsync(int id)
    {
        try
        {
            await _servico.DeletarAsync(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }
}