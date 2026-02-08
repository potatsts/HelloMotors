using HelloMotors.Model;
using HelloMotors.Repository;

namespace HelloMotors.Service;

public class ProprietarioService
{
    private ProprietarioRepository _repositorio;
    public ProprietarioService(ProprietarioRepository repositorio)
    {
        _repositorio = repositorio;
    }

    //listar todos
    public async Task<List<Proprietario>> ListarAsync()
    {
        return await _repositorio.ListarAsync();
    }
    //cadastrar
    //atualizar
    //deletar
}