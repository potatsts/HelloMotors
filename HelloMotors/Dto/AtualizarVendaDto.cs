namespace Dto;

public class AtualizarVendaDto
{
    public DateTime DataVenda { get; set; }
    public decimal ValorFinal { get; set; }
    public int idVendedor { get; set; }
    public int idChassi { get; set; }
}