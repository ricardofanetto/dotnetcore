using System.Net.Http;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using dotnetcore.calculate_interest;

namespace dotnetcore.test.Integration
{
  public class CalculateInterestContextApi
  {
    public HttpClient Client { get; set; }
    private TestServer _server;

    public CalculateInterestContextApi()
    {
      SetupClient();
    }

    private void SetupClient()
    {
      var config = new ConfigurationBuilder()
     .AddJsonFile("calculate.appsettings.Test.json")
     .Build();
      _server = new TestServer(new WebHostBuilder().UseConfiguration(config).UseStartup<Startup>());
      Client = _server.CreateClient();
    }
  }
}