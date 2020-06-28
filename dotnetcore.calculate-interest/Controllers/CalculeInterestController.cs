
using System;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using dotnetcore.calculate_interest.Models;

namespace dotnetcore.calculate_interest.Controllers
{
  public class CalculateInterestController : Controller
  {
    private string urlRepository;
    public CalculateInterestController(IConfiguration configuration)
    {
      this.urlRepository = configuration.GetSection("application:repository").Value;
    }

    private double GetTaxaJuros(IHttpClientFactory httpClient)
    {
      HttpClient client = httpClient.CreateClient("api-interest-rate");
      HttpResponseMessage response = client.GetAsync("/taxaJuros").Result;

      string conteudo = response.Content.ReadAsStringAsync().Result;
      TaxaResponse result = JsonConvert.DeserializeObject<TaxaResponse>(conteudo);
      return result.Taxa;
    }

    [Route("calculajuros")]
    [HttpGet]
    public CalculoJurosResponse Get(
      [FromQuery] double valorInicial,
      [FromQuery] int meses,
      [FromServices] IHttpClientFactory httpClientFactory)
    {
      double taxa = this.GetTaxaJuros(httpClientFactory);
      double total = valorInicial;
      for (int i = 0; i < meses; i++) total *= (1 + taxa);
      return new CalculoJurosResponse(total);
    }

    [HttpGet]
    [Route("showmethecode")]
    public GitHubResponse GetShowMeTheCode()
    {
      return new GitHubResponse(this.urlRepository);
    }
  }
}