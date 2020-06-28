using Microsoft.AspNetCore.Mvc;

namespace dotnetcore.interest_rate.Controllers
{
  public class InterestRateController : Controller
  {
    [Route("taxaJuros")]
    public double Get()
    {
      return 0.01;
    }
  }
}
