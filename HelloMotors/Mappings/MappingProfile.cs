using AutoMapper;
using Dto;
using HelloMotors.Model;

namespace HelloMotors.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // CreateMap<CadastrarVendedorDto, Vendedor>();
        // CreateMap<AtualizarVendedorDto, Vendedor>();

        // CreateMap<CadastrarProprietarioDto, Proprietario>();
        // CreateMap<AtualizarProprietarioDto, Proprietario>();

        CreateMap<CadastrarVeiculoDto, Veiculo>();
        CreateMap<AtualizarVeiculoDto, Veiculo>();
        CreateMap<Veiculo, EstoqueVeiculoDto>();

        CreateMap<CadastrarVendaDto, Venda>();
        CreateMap<AtualizarVendaDto, Venda>();
    }
}