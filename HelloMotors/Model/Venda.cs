using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace HelloMotors.Model;

public class Venda
{
    [Key]
    public int IdVenda { get; set; }
    [Required]
    public DateTime DataVenda { get; set; }
    public required decimal ValorFinal { get; set; }
    public required int IdVendedor { get; set; }
    [ForeignKey("IdVendedor")]
    public Vendedor Vendedor { get; set; } = null!;
    public required int IdVeiculo { get; set; }
    [ForeignKey("IdVeiculo")]
    public Veiculo Veiculo { get; set; } = null!;
}
