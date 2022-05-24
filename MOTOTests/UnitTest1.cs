using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;

namespace MOTOTests
{
    public class Tests
    {
        internal class DemoAppFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
        {
            protected override void ConfigureWebHost(IWebHostBuilder builder)
            {

            }
        }

        string? content = "";

        [OneTimeSetUp]
        public async Task Setup()
        {
            var factory = new DemoAppFactory<Program>();
            var client = factory.CreateClient();
            var response = await client.GetAsync("/WeatherForecast");
            content = await response.Content.ReadAsStringAsync();
        }

        [Test]
        public void Test1()
        {
            StringAssert.Contains("temperatureC", content);
        }
    }
}