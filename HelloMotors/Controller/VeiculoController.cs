using Microsoft.AspNetCore.Mvc;
using HelloMotors.Model;
using HelloMotors.Service;
using Dto;
using Swashbuckle.AspNetCore.Annotations;

namespace HelloMotors.Controller;

[ApiController]
[Route("api/[controller]")]
public class VeiculoController : ControllerBase
{
    private VeiculoService _servico;

    public VeiculoController(VeiculoService servico)
    {
        _servico = servico;
    }

    [SwaggerOperation(Summary = "Lista os veículos disponíveis")] 
    [HttpGet]
    public async Task<ActionResult<List<EstoqueVeiculoDto>>> ListarAsync()
    {
        try
        {
            List<EstoqueVeiculoDto> estoqueVeiculoDtos = await _servico.ListarAsync();
            return Ok(estoqueVeiculoDtos);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    [SwaggerOperation(Summary = "Lista veículos ordenados por quilimetragem filtrados por versão do Sistema ")] 
    [HttpGet("por-quilometragem/{versaoSistema}")]
    public async Task<ActionResult<List<Veiculo>>> ListarPorQuilometragemAsync(string versaoSistema)
    {
        try
        {
            List<Veiculo> listPorQuilometragem = await _servico.ListarPorQuilometragemAsync(versaoSistema);
            return Ok(listPorQuilometragem);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    [SwaggerOperation(Summary = "Busca veículo por Id")] 
    [HttpGet("{id}")]
    public async Task<ActionResult<Veiculo>> GetPorId(int id)
    {
        try
        {
            var veiculo = await _servico.BuscarPorIdAsync(id);
            return Ok(veiculo);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    [SwaggerOperation(Summary = "Cria um veículo")] 
    [HttpPost]
    public async Task<ActionResult<Veiculo>> InserirAsync(CadastrarVeiculoDto dto)
    {
        try
        {
            var veiculo = await _servico.InserirAsync(dto);
            return Created("", veiculo);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

    }

    [SwaggerOperation(Summary = "Atualiza os dados de um veículo")] 
    [HttpPut("{id}")]
    public async Task<ActionResult> AtualizarAsync(int id, AtualizarVeiculoDto dto)
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

    [SwaggerOperation(Summary = "Deleta o registro de um veículo")] 
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