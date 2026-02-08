using Microsoft.AspNetCore.Mvc;
using HelloMotors.Model;
using HelloMotors.Service;
using Dto;

namespace HelloMotors.Controller;

[ApiController]
[Route("[controller]")]
public class ProprietarioController : ControllerBase
{
    private ProprietarioService _servico;

    public ProprietarioController(ProprietarioService servico)
    {
        _servico = servico;
    }

    //Get --> listar todos os proprietários
    [HttpGet]
    public async Task<ActionResult<List<Proprietario>>> ListarAsync()
    {
        return await _servico.ListarAsync();
    }

    //Post --> adicionar um novo proprietário
    [HttpPost]
    public async Task<ActionResult<Proprietario>> CriarAsync(CadastrarProprietarioDto dto)
    {
        var proprietario = await _servico.CriarAsync(dto);
        return Ok(proprietario);
    }

    //Put --> atualizar dados de um proprietário

    //Delete --> deletar um proprietário
}