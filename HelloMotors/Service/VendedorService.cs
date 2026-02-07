using HelloMotors.Model;
using HelloMotors.Repository;

namespace HelloMotors.Service;

public class VendedorService
{
    private readonly VendedorRepository _repositorio;

    public VendedorService(VendedorRepository repositorio)
    {
        _repositorio = repositorio;
    }

    public async Task<List<Vendedor>> ListarAsync()
    {
        return await _repositorio.ListarAsync();
    }
}