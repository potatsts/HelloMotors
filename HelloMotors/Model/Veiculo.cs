using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace HelloMotors.Model;

[Index(nameof(Chassi), IsUnique = true)]
public class Veiculo
{
    [Key]
    public int IdVeiculo { get; set; }
    [Required]
    [MaxLength(20)]
    public required string Chassi { get; set; }
    public required string Modelo { get; set; }
    public required string VersaoSistema { get; set; }
    public required int Ano { get; set; }
    public required string Cor { get; set; }
    public required decimal Quilometragem { get; set; }
    public required decimal Valor { get; set; }
    public string? Acessorios { get; set; }
    public int? IdProprietario { get; set; } = null;
    [ForeignKey("IdProprietario")]
    public Proprietario? Proprietario { get; set; }
}

