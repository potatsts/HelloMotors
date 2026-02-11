using HelloMotors.Model;
using HelloMotors.Repository;
using Dto;
using AutoMapper;
using System.Text.RegularExpressions;

namespace HelloMotors.Service;

public class ProprietarioService
{
    private readonly ProprietarioRepository _repositorio;
    private readonly IMapper _mapper;
    public ProprietarioService(ProprietarioRepository repositorio, IMapper mapper)
    {
        _repositorio = repositorio;
        _mapper = mapper;
    }

    public async Task<List<Proprietario>> ListarAsync()
    {
        return await _repositorio.ListarAsync();
    }

    public async Task<Proprietario> BuscarPorIdAsync(int id)
    {
        return await _repositorio.BuscarPorIdAsync(id) ?? throw new KeyNotFoundException($"Proprietário com id {id} não encontrado!");
    }

    public async Task<Proprietario> InserirAsync(CadastrarProprietarioDto dto)
    {
        ValidarDocumento(dto.CpfCnpj);
        var proprietario = _mapper.Map<Proprietario>(dto);
        return await _repositorio.InserirAsync(proprietario);
    }

    public async Task AtualizarAsync(int id, AtualizarProprietarioDto dto)
    {
        ValidarDocumento(dto.CpfCnpj);
        var proprietario = await _repositorio.BuscarPorIdAsync(id) ?? throw new KeyNotFoundException($"Proprietário com id {id} não encontrado!");
        _mapper.Map(dto, proprietario);
        await _repositorio.AtualizarAsync(proprietario);
    }

    public async Task DeletarAsync(int id)
    {
        var proprietario = await _repositorio.BuscarPorIdAsync(id) ?? throw new KeyNotFoundException($"Proprietário com id {id} não encontrado!");
        await _repositorio.DeletarAsync(proprietario);
    }

    public static bool ValidacaoCpf(string cpf)
    {
        if (string.IsNullOrWhiteSpace(cpf)) return false;

        string tempCpf = Regex.Replace(cpf, @"[^\d]", "");

        if (tempCpf.Length != 11) return false;

        string[] sequenciaInvalida =
        {
            "00000000000", "11111111111", "22222222222",
            "33333333333", "44444444444", "55555555555",
            "66666666666", "77777777777", "88888888888",
            "99999999999"
        };

        foreach (var seq in sequenciaInvalida)
        {
            if (tempCpf == seq) return false;
        }

        return true;
    }
    public static bool ValidacaoCnpj(string cnpj)
    {
        if (string.IsNullOrWhiteSpace(cnpj)) return false;

        string tempCnpj = Regex.Replace(cnpj, @"[^\d]", "");

        if (tempCnpj.Length != 14) return false;

        string[] sequenciaInvalida =
        {
            "00000000000000", "11111111111111", "22222222222222",
            "33333333333333", "44444444444444", "55555555555555",
            "66666666666666", "77777777777777", "88888888888888",
            "99999999999999"
        };

        foreach (var seq in sequenciaInvalida)
        {
            if (tempCnpj == seq) return false;
        }

        return true;
    }

    private static void ValidarDocumento(string documento)
    {
        if (!ValidacaoCpf(documento) && !ValidacaoCnpj(documento))
            throw new ArgumentException("CPF ou CNPJ em formato inválido");
    }
}