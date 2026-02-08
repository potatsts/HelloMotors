using Microsoft.AspNetCore.Mvc;
using HelloMotors.Model;
using HelloMotors.Service;
using Dto;

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
    //Get --> listar todos os veículos

    //Post --> adicionar um novo veículo

    //Put --> atualizar dados de um veículo

    //Delete --> deletar um veículo

    //Get --> lista veículos por quilometragem filtrados por versão do sistema
    [HttpGet]
    public async Task<ActionResult<List<Veiculo>>> ListarAsync()
    {
        return await _servico.ListarAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Veiculo>> InserirAsync(CadastrarVeiculoDto dto)
    {
        var veiculo = await _servico.InserirAsync(dto);
        return Ok(veiculo);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Veiculo>> AtualizarAsync(int id, AtualizarVeiculoDto dto)
    {
        var veiculo = await _servico.AtualizarAsync(id, dto);
        return Ok(veiculo);
    }

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
}