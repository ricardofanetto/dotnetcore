using System.Net;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using System.Net.Http;
using dotnetcore.interest_rate.Models;
using Newtonsoft.Json;

namespace dotnetcore.test.Integration
{
  public class InterestRateApi
  {
    private readonly InterestRateContextApi _testContext;
    public InterestRateApi()
    {
      _testContext = new InterestRateContextApi();
    }

    [Fact]
    public async Task Get_ReturnsOkResponse()
    {
      HttpResponseMessage response = await _testContext.Client.GetAsync("/taxajuros");
      response.EnsureSuccessStatusCode();
      response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task Get_ReturnTaxa001()
    {
      HttpResponseMessage response = await _testContext.Client.GetAsync("/taxajuros");
      response.EnsureSuccessStatusCode();
      response.StatusCode.Should().Be(HttpStatusCode.OK);
      string bodyResponse = await response.Content.ReadAsStringAsync();

      TaxaResponse objectResponse = JsonConvert.DeserializeObject<TaxaResponse>(bodyResponse);
      objectResponse.Should().Match<TaxaResponse>(x => x.Taxa == 0.01);
    }
  }
}