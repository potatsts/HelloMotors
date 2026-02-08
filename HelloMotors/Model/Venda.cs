using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace HelloMotors.Model;

public class Venda
{
    [Key]
    public int IdVenda { get; set; }
    [Required]
    public DateTime DataVenda { get; set; }
    public decimal ValorFinal { get; set; }
    public int IdVendedor { get; set; }
    [ForeignKey("IdVendedor")]
    public Vendedor? Vendedor { get; set; }
    public int IdChassi { get; set; }
    [ForeignKey("IdChassi")]
    public Veiculo? Veiculo { get; set; }
}