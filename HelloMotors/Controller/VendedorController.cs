using Microsoft.AspNetCore.Mvc;
using HelloMotors.Model;
using HelloMotors.Repository;
using HelloMotors.Service;
using Dto;

namespace HelloMotors.Controller;

[ApiController]
[Route("api/[controller]")]
public class VendedorController : ControllerBase
{
    private VendedorService _servico;

    public VendedorController(VendedorService servico)
    {
        _servico = servico;
    }

    //Get --> listar todos os vendedores
    [HttpGet]
    public async Task<ActionResult<List<Vendedor>>> ListarAsync()
    {
        return await _servico.ListarAsync();
    }


    //Post --> adicionar um novo vendedor
    [HttpPost]
    public async Task<ActionResult<Vendedor>> CriarAsync(CadastrarVendedorDto dto)
    {
        var vendedor = await _servico.CriarAsync(dto);
        return Ok(vendedor);
    }

    //Put --> atualizar dados de um vendedor
    [HttpPut("{id}")]
    public async Task<ActionResult<Vendedor>> AtualizarAsync(int id, AtualizarVendedorDto dto)
    {
        var vendedor = await _servico.AtualizarAsync(id, dto);
        return Ok(vendedor);
    }

    //Delete --> deletar um vendedor
    [HttpDelete("{id}")]
    public async Task<ActionResult<Vendedor>> DeletarAsync(int id)
    {
        var vendedor = await _servico.DeletarAsync(id);
        if (vendedor == null)
        {
            return NotFound("Vendedor não encontrado");
        }
        return Ok(vendedor);
    }
    
}