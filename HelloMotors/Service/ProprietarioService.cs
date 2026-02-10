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
    public async Task<Proprietario> CriarAsync(CadastrarProprietarioDto dto)
    {
        if (!ValidacaoCpf(dto.CpfCnpj) || !ValidacaoCnpj(dto.CpfCnpj))
        {
            throw new Exception("CPF ou CNPJ em formato inválido");
        }
        var proprietario = _mapper.Map<Proprietario>(dto);
        return await _repositorio.CriarAsync(proprietario);
    }
    public async Task<Proprietario?> AtualizarAsync(int id, AtualizarProprietarioDto dto)
    {
        if (!ValidacaoCpf(dto.CpfCnpj) || !ValidacaoCnpj(dto.CpfCnpj))
        {
            throw new Exception("CPF ou CNPJ em formato inválido");
        }
        return await _repositorio.AtualizarAsync(id, dto);
    }
    public async Task<Proprietario?> DeletarAsync(int id)
    {
        return await _repositorio.DeletarAsync(id);
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

}