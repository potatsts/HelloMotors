using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace AutoCars.Models;

public class Vendedor
{
    [Key] //chave primária
    public int IdVendedor { get; set; }
    [Required] //not null 
    [MaxLength(100)] //tamanho máximo
    public string? Nome { get; set; }
    public decimal SalarioBase { get; set; }
}


