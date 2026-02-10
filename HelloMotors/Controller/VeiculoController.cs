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
    public async Task<ActionResult<List<Veiculo>>> ListarAsync()
    {
        return await _servico.ListarAsync();
    }

    [SwaggerOperation(Summary = "Cria um veículo")]
    [HttpPost]
    public async Task<ActionResult<Veiculo>> InserirAsync(CadastrarVeiculoDto dto)
    {
        var veiculo = await _servico.InserirAsync(dto);
        return Ok(veiculo);
    }

    [SwaggerOperation(Summary = "Altera um veículo existente")]
    [HttpPut("{id}")]
    public async Task<ActionResult<Veiculo>> AtualizarAsync(int id, AtualizarVeiculoDto dto)
    {
        var veiculo = await _servico.AtualizarAsync(id, dto);
        return Ok(veiculo);
    }

    [SwaggerOperation(Summary = "Deleta um veículo")]
    [HttpDelete("{id}")]
    public async Task<ActionResult<Veiculo>> DeletarAsync(int id)
    {
        var veiculo = await _servico.DeletarAsync(id);
        if (veiculo == null)
        {
            return NotFound("Veículo não encontrado.");
        }
        return Ok(veiculo);
    }

    [SwaggerOperation(Summary = "Lista veículos ordenados por quilimetragem filtrados por versão do Sistema ")]
    [HttpGet("por-quilometragem/{versaoSistema}")]
    public async Task<ActionResult<List<Veiculo>>> ListarPorQuilometragemAsync(string versaoSistema)
    {
        return Ok(await _servico.ListarPorQuilometragemAsync(versaoSistema));
    }

    [SwaggerOperation(Summary = "Busca veículo por Id")]
    [HttpGet("por-{id}")]
    public async Task<ActionResult<Veiculo>> GetPorId(int id)
    {
        return Ok(await _servico.GetPorIdAsync(id));
    }
}