using Microsoft.AspNetCore.Mvc;
using HelloMotors.Model;
using HelloMotors.Repository;
using HelloMotors.Service;

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

    //Put --> atualizar dados de um vendedor

    //Delete --> deletar um vendedor

}