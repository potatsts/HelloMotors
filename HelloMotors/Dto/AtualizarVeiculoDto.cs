namespace Dto;

public class AtualizarVeiculoDto
{
    public string VersaoSistema { get; set; } = "";
    public decimal Quilometragem { get; set; }
    public decimal Valor { get; set; }
    public string Acessorios { get; set; } = "";
    public int? IdProprietario { get; set; }
}
