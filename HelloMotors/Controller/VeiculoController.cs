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
        List<EstoqueVeiculoDto> estoqueVeiculoDtos = await _servico.ListarAsync();
        return Ok(estoqueVeiculoDtos);
    }

    [SwaggerOperation(Summary = "Lista veículos ordenados por quilimetragem filtrados por versão do Sistema ")] 
    [HttpGet("por-quilometragem/{versaoSistema}")]
    public async Task<ActionResult<List<Veiculo>>> ListarPorQuilometragemAsync(string versaoSistema)
    {

        List<Veiculo> listPorQuilometragem = await _servico.ListarPorQuilometragemAsync(versaoSistema);
        return Ok(listPorQuilometragem);
    }

    [SwaggerOperation(Summary = "Busca veículo por Id")] 
    [HttpGet("{id}")]
    public async Task<ActionResult<Veiculo>> GetPorId(int id)
    {
        var veiculo = await _servico.BuscarPorIdAsync(id);
        return Ok(veiculo);
    }

    [SwaggerOperation(Summary = "Cria um veículo")] 
    [HttpPost]
    public async Task<ActionResult<Veiculo>> InserirAsync(CadastrarVeiculoDto dto)
    {
        var veiculo = await _servico.InserirAsync(dto);
        return Created("", veiculo);
    }

    [SwaggerOperation(Summary = "Atualiza os dados de um veículo")] 
    [HttpPut("{id}")]
    public async Task<ActionResult> AtualizarAsync(int id, AtualizarVeiculoDto dto)
    {
        await _servico.AtualizarAsync(id, dto);
        return NoContent();
    }

    [SwaggerOperation(Summary = "Deleta o registro de um veículo")] 
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeletarAsync(int id)
    {

        await _servico.DeletarAsync(id);
        return NoContent();
    }
}