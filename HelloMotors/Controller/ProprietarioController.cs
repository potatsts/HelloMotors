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
        return await _servico.ListarAsync();
    }

    [SwaggerOperation(Summary = "Cria o registro de um novo proprietário")]
    [HttpPost]
    public async Task<ActionResult<Proprietario>> CriarAsync(CadastrarProprietarioDto dto)
    {
        var proprietario = await _servico.CriarAsync(dto);
        return Ok(proprietario);
    }

    [SwaggerOperation(Summary = "Atualiza os dados de um proprietário")]
    [HttpPut("{id}")]
    public async Task<ActionResult<Proprietario>> AtualizarAsync(int id, AtualizarProprietarioDto dto)
    {
        var proprietario = await _servico.AtualizarAsync(id, dto);
        return Ok(proprietario);
    }

    [SwaggerOperation(Summary = "Deleta o registro de um proprietário")]
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