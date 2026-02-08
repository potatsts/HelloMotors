using Dto;
using HelloMotors.Model;
using HelloMotors.Repository;

namespace HelloMotors.Service;

public class VendaService
{
    private VendaRepository _repositorio;
    public VendaService(VendaRepository repositorio)
    {
        _repositorio = repositorio;
    }

    public async Task<List<Venda>> ListarAsync()
    {
        return await _repositorio.ListarAsync();
    }

    public async Task<Venda?> DeletarAsync(int id)
    {
        return await _repositorio.DeletarAsync(id);
    }
}