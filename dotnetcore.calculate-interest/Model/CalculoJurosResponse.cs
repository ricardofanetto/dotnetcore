
namespace dotnetcore.calculate_interest.Models
{
  public class CalculoJurosResponse
  {
    public string TotalJuros { get; private set; }  
    public CalculoJurosResponse(double valor)
    {
        this.TotalJuros = valor.ToString("N2");
    }
  }
}