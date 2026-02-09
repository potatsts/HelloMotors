using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace HelloMotors.Model;

public class Veiculo
{
    [Key]
    public int IdChassi { get; set; }
    [Required]
    [MaxLength(20)]
    public string? Chassi { get; set; }
    public string? Modelo { get; set; }
    public string? VersaoSistema { get; set; }
    public int Ano { get; set; }
    public string? Cor { get; set; }
    public decimal Quilometragem { get; set; }
    public decimal Valor { get; set; }
    public string? Acessorios { get; set; }
    public int? IdProprietario { get; set; }
    [ForeignKey("IdProprietario")]
    public Proprietario? Proprietario { get; set; }
}