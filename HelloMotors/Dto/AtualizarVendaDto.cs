namespace Dto;

public class AtualizarVendaDto
{
    public DateTime DataVenda { get; set; }
    public decimal ValorFinal { get; set; }
    public int IdVendedor { get; set; }
    public int IdVeiculo { get; set; }
}