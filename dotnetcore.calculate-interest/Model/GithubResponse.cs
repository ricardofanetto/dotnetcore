namespace dotnetcore.calculate_interest.Models
{
  public class GitHubResponse
  {
    public string Repository { get; set; }

    public GitHubResponse(string repositoy)
    {
      this.Repository = repositoy;
    }
  }
}