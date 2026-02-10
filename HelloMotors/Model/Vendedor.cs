using System.ComponentModel.DataAnnotations;
namespace HelloMotors.Model;

public class Vendedor
{
    [Key]
    public int IdVendedor { get; set; }
    [Required]
    [MaxLength(100)]
    public required string Nome { get; set; }
    public decimal SalarioBase { get; set; }

}