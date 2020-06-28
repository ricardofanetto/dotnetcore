namespace dotnetcore.interest_rate.Models
{
  public class TaxaResponse
  {
    public double Taxa { get; private set; }
    public TaxaResponse(double taxa)
    {
      this.Taxa = taxa;
    }
  }
}