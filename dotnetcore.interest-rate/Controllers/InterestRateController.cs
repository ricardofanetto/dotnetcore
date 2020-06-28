using dotnetcore.interest_rate.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace dotnetcore.interest_rate.Controllers
{
  public class InterestRateController : Controller
  {
    private double taxa = 0;
    public InterestRateController(IConfiguration configuration)
    {
      double.TryParse(configuration.GetSection("application:tax").Value, out taxa);
    }

    [Route("taxaJuros")]
    public JsonResult Get()
    {
      return new JsonResult(new TaxaResponse(this.taxa));
    }
  }
}
