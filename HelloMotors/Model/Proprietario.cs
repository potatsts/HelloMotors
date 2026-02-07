using System.ComponentModel.DataAnnotations;
namespace AutoCars.Models;

public class Proprietario
{
    [Key] //chave primária
    public int IdProprietario { get; set; }
    [Required] //not null 
    [MaxLength(100)] //tamanho máximo
    public string? Nome { get; set; }
    public string? CpfCnpj { get; set; }
    public string? Endereco { get; set; }
    public string? Email { get; set; }
    public string? Telefone { get; set; }
    public string? DadosPessoais { get; set; }
}