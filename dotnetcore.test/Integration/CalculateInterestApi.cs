using System.Net;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using System.Net.Http;
using Newtonsoft.Json;
using dotnetcore.calculate_interest.Models;
using System;

namespace dotnetcore.test.Integration
{
  public class CalculateInterestApi
  {
    private readonly CalculateInterestContextApi _testContext;
    public CalculateInterestApi()
    {
      _testContext = new CalculateInterestContextApi();
    }

    [Fact]
    public async Task Get_ReturnsOkResponse()
    {
      HttpResponseMessage response = await _testContext.Client.GetAsync("/showmethecode");
      response.EnsureSuccessStatusCode();
      response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task Get_ReturnRepositoryUrl()
    {
      HttpResponseMessage response = await _testContext.Client.GetAsync("/showmethecode");
      response.EnsureSuccessStatusCode();
      response.StatusCode.Should().Be(HttpStatusCode.OK);

      string bodyResponse = await response.Content.ReadAsStringAsync();

      GitHubResponse objectResponse = JsonConvert.DeserializeObject<GitHubResponse>(bodyResponse);
      objectResponse.Should().Match<GitHubResponse>(x => x.Repository == "https://github.com/ricardofanetto/dotnetcore.git");
    }

    [Fact]
    public async Task Get_Returns1050WhenCalculateTax()
    {
      HttpResponseMessage response = await _testContext.Client.GetAsync($"/calculajuros?valorinicial=100&meses=5");
      response.EnsureSuccessStatusCode();
      response.StatusCode.Should().Be(HttpStatusCode.OK);
      string bodyResponse = await response.Content.ReadAsStringAsync();
      bodyResponse.Should().Contain("105.10");
    }

  }
}