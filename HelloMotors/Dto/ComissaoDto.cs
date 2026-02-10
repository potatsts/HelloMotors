namespace Dto;

public class ComissaoDto
{
    public int IdVendedor {get; set;}
    public string Nome {get; set;} = "";
    public decimal TotalVendasMes {get; set;}
    public decimal SalarioBase {get; set;}
    public decimal TotalComissao {get; set;}
    public decimal SalarioFinal {get; set;}
}