using System.Net.Http;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using dotnetcore.interest_rate;
using Microsoft.Extensions.Configuration;

namespace dotnetcore.test.Integration
{
  public class InterestRateContextApi
  {
    public HttpClient Client { get; set; }
    private TestServer _server;

    public InterestRateContextApi()
    {
      SetupClient();
    }

    private void SetupClient()
    {

      var config = new ConfigurationBuilder()
     .AddJsonFile("tax.appsettings.Test.json")
     .Build();
      _server = new TestServer(new WebHostBuilder().UseConfiguration(config).UseStartup<Startup>());
      Client = _server.CreateClient();
    }
  }
}