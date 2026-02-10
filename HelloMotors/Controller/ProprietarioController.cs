using Microsoft.AspNetCore.Mvc;
using HelloMotors.Model;
using HelloMotors.Service;
using Dto;
using Swashbuckle.AspNetCore.Annotations;

namespace HelloMotors.Controller;

[ApiController]
[Route("api/[controller]")]
public class ProprietarioController : ControllerBase
{
    private ProprietarioService _servico;

    public ProprietarioController(ProprietarioService servico)
    {
        _servico = servico;
    }

    [SwaggerOperation(Summary = "Lista os proprietários")] //feito
    [HttpGet]
    public async Task<ActionResult<List<Proprietario>>> ListarAsync()
    {
        try
        {
            List<Proprietario> proprietarios = await _servico.ListarAsync();
           return Ok(proprietarios); 
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
        
    }

    [SwaggerOperation(Summary = "Cria o registro de um novo proprietário")] //feito
    [HttpPost]
    public async Task<ActionResult<Proprietario>> CriarAsync(CadastrarProprietarioDto dto)
    {
        try
        {
            var proprietario = await _servico.CriarAsync(dto);
            return Created("",proprietario);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        
    }

    [SwaggerOperation(Summary = "Atualiza os dados de um proprietário")] //feito
    [HttpPut("{id}")]
    public async Task<ActionResult<Proprietario>> AtualizarAsync(int id, AtualizarProprietarioDto dto)
    {
        try
        {
            var proprietario = await _servico.AtualizarAsync(id, dto);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

    }

    [SwaggerOperation(Summary = "Deleta o registro de um proprietário")] //Rever===========================================================
    [HttpDelete("{id}")]
    public async Task<ActionResult<Proprietario?>> DeletarAsync(int id)
    {
        var proprietario = await _servico.DeletarAsync(id);
        if (proprietario == null)
        {
            return NotFound("Vendedor não encontrado");
        }
        return Ok(proprietario);
    }
}