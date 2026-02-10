using AutoMapper;
using Dto;
using HelloMotors.Data;
using HelloMotors.Model;
using Microsoft.EntityFrameworkCore;

namespace HelloMotors.Repository;

public class ProprietarioRepository
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;
    public ProprietarioRepository(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<Proprietario>> ListarAsync()
    {
        return await _context.Proprietarios.ToListAsync();
    }

    public async Task<Proprietario> CriarAsync(Proprietario proprietario)
    {
        _context.Proprietarios.Add(proprietario);
        await _context.SaveChangesAsync();
        return proprietario;
    }

    public async Task<Proprietario?> AtualizarAsync(int id, AtualizarProprietarioDto dto)
    {
        var proprietario = await _context.Proprietarios.FindAsync(id);
        if (proprietario == null)
        {
            return null;
        }

        _mapper.Map(dto, proprietario);

        await _context.SaveChangesAsync();
        return proprietario;
    }

    public async Task<Proprietario?> DeletarAsync(int id)
    {
        var proprietario = await _context.Proprietarios.FindAsync(id);
        if (proprietario == null)
        {
            return null;
        }

        _context.Proprietarios.Remove(proprietario);
        await _context.SaveChangesAsync();
        return proprietario;
    }
}