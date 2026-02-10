using Microsoft.AspNetCore.Mvc;
using HelloMotors.Model;
using HelloMotors.Service;
using Dto;
using Swashbuckle.AspNetCore.Annotations;

namespace HelloMotors.Controller;

[ApiController]
[Route("[controller]")]
public class VendaController : ControllerBase
{
    private VendaService _servico;

    public VendaController(VendaService servico)
    {
        _servico = servico;
    }
    //Get --> listar todas as vendas
    [SwaggerOperation(Summary = "Lista as vendas realizadas")]
    [HttpGet]
    public async Task<ActionResult<List<Venda>>> ListarAsync()
    {
        return await _servico.ListarAsync();
    }

    //Post --> adicionar uma nova venda (relacionando veículo e vendedor)
    [SwaggerOperation(Summary = "Registra uma nova venda")]
    [HttpPost]
    public async Task<ActionResult<Venda>> InserirAsync(CadastrarVendaDto dto)
    {
        var venda = await _servico.InserirAsync(dto);
        return Ok(venda);
    }

    //Put --> atualizar dados de uma venda
    [SwaggerOperation(Summary = "Atualiza uma venda realizada")]
    [HttpPut("{id}")]
    public async Task<ActionResult<Venda>> AtualizarAsync(int id, AtualizarVendaDto dto)
    {
        var venda = await _servico.AtualizarAsync(id, dto);
        if (venda == null)
        {
            return NotFound("Venda não encontrada");
        }
        return Ok(venda);
    }
    
    //Delete --> deletar uma venda
    [SwaggerOperation(Summary = "Deleta uma venda")]
    [HttpDelete("{id}")]
    public async Task<ActionResult<Venda>> DeletarAsync(int id)
    {
        var venda = await _servico.DeletarAsync(id);
        if (venda == null)
        {
            return NotFound("Venda não encontrada");
        }
        return Ok(venda);
    }

}