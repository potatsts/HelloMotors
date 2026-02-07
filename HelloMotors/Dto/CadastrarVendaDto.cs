namespace Dto;

public class CadastrarVendaDto
{
    public int idVenda { get; set; }
    public DateTime DataVenda { get; set; }
    public decimal ValorFinal { get; set; }
    public int idVendedor { get; set; }
    public int idChassi { get; set; }
}
