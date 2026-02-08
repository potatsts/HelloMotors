using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace HelloMotors.Model;

public class Venda
{
    [Key] //chave primária
    public int IdVenda { get; set; }
    [Required] //not null 
    public DateTime DataVenda { get; set; }
    public decimal ValorFinal { get; set; }
    //chave estrangeira
    public int IdVendedor { get; set; } //cria a coluna na tabela Venda
    public Vendedor? Vendedor { get; set; } //necessário para navegação entre as tabelas
    public int IdChassi { get; set; } 
    public Veiculo? Veiculo { get; set; } 
}