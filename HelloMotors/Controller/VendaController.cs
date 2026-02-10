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

    [SwaggerOperation(Summary = "Lista as vendas realizadas")] //feito
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

    [SwaggerOperation(Summary = "Registra uma nova venda")] //feito
    [HttpPost]
    public async Task<ActionResult<Venda>> InserirAsync(CadastrarVendaDto dto)
    {
        try
        {
            var venda = await _servico.InserirAsync(dto);
            return Created("",venda);        
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // [SwaggerOperation(Summary = "Atualiza uma venda realizada")]
    // [HttpPut("{id}")]
    // public async Task<ActionResult<Venda>> AtualizarAsync(int id, AtualizarVendaDto dto)
    // {
    //     var venda = await _servico.AtualizarAsync(id, dto);
    //     if (venda == null)
    //     {
    //         return NotFound("Venda não encontrada");
    //     }
    //     return Ok(venda);
    // }

    [SwaggerOperation(Summary = "Deleta uma venda")] //Rever===========================================================
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