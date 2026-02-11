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

    [SwaggerOperation(Summary = "Lista os proprietários")]
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

    [SwaggerOperation(Summary = "Busca proprietário por Id")]
    [HttpGet("{id}")]
    public async Task<ActionResult<Proprietario>> GetPorId(int id)
    {
        try
        {
            var proprietario = await _servico.BuscarPorIdAsync(id);
            return Ok(proprietario);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    [SwaggerOperation(Summary = "Cria o registro de um novo proprietário")] 
    [HttpPost]
    public async Task<ActionResult<Proprietario>> InserirAsync(CadastrarProprietarioDto dto)
    {
        try
        {
            var proprietario = await _servico.InserirAsync(dto);
            return Created("", proprietario);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

    }

    [SwaggerOperation(Summary = "Atualiza os dados de um proprietário")] 
    [HttpPut("{id}")]
    public async Task<ActionResult> AtualizarAsync(int id, AtualizarProprietarioDto dto)
    {
        try
        {
            await _servico.AtualizarAsync(id, dto);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

    }

    [SwaggerOperation(Summary = "Deleta o registro de um proprietário")] 
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