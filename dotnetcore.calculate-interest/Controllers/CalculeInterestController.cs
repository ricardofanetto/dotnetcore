using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace dotnetcore.calculate_interest.Controllers
{
  public class CalculateInterestController : Controller
  {
    private readonly IHttpClientFactory _clientFactory;
    public CalculateInterestController(IHttpClientFactory clientFactory)
    {
      _clientFactory = clientFactory;

    }

    [Route("calculajuros")]
    [HttpGet]
    public async Task Get(
      [FromQuery] int valorInicial,
      [FromQuery] int meses)
    {
      var client = _clientFactory.CreateClient();
      var response = await client.GetAsync("/taxaJuros");

      if (response.IsSuccessStatusCode)
      {
        using (var responseStream = await response.Content.ReadAsStreamAsync())
        {
          // PullRequests = await JsonSerializer.DeserializeAsync
          //               <IEnumerable<GitHubPullRequest>>(responseStream);

        }
      }
      // var x = await http.GetAsync("http://localhost:5001/");
      // return 0.0;

    }

    [Route("showmethecode")]
    [HttpGet]
    public string GetShowMeTheCode()
    {
      return "";
    }
  }
}