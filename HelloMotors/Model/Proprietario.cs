using System.ComponentModel.DataAnnotations;
namespace HelloMotors.Model;

public class Proprietario
{
    [Key]
    public int IdProprietario { get; set; }
    [Required]
    [MaxLength(100)]
    public string? Nome { get; set; }
    public string? CpfCnpj { get; set; }
    public string? Endereco { get; set; }
    public string? Email { get; set; }
    public string? Telefone { get; set; }
    public string? DadosPessoais { get; set; }
}