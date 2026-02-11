using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace HelloMotors.Model;

[Index(nameof(CpfCnpj), IsUnique = true)]
public class Proprietario
{
    [Key]
    public int IdProprietario { get; set; }
    [Required]
    [MaxLength(100)]
    public required string Nome { get; set; }
    public required string CpfCnpj { get; set; }
    public required string Endereco { get; set; }
    public required string Email { get; set; }
    public required string Telefone { get; set; }
    public string? DadosPessoais { get; set; }
}