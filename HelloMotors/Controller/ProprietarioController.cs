using Microsoft.AspNetCore.Mvc;
using HelloMotors.Model;
using HelloMotors.Service;

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

    //Post --> adicionar um novo proprietário

    //Put --> atualizar dados de um proprietário

    //Delete --> deletar um proprietário
}