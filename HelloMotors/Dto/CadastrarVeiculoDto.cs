namespace Dto;

public class CadastrarVeiculoDto
{
    public string Chassi { get; set; } = "";
    public string Modelo { get; set; } = "";
    public string VersaoSistema { get; set; } = "";
    public int Ano { get; set; }
    public string Cor { get; set; } = "";
    public decimal Quilometragem { get; set; }
    public decimal Valor { get; set; }
    public string Acessorios { get; set; } = "";
}
