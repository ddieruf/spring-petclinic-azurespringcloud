using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using spring_petclinic_vets_api;
using spring_petclinic_vets_api.DTOs;
using System.Linq;
using spring_petclinic_vets_api.Data;

namespace spring_petclinic_vets_integration_test.Controllers
{
  [Collection("Vets API Test Collection")]
  public class Vets : IClassFixture<CustomersAppFactory<Startup>>, IDisposable
  {
    private readonly HttpClient _client;
    private readonly CustomersAppFactory<Startup> _factory;

    public Vets(CustomersAppFactory<Startup> factory, ITestOutputHelper outputHelper)
    {
      factory.OutputHelper = outputHelper;
      _factory = factory;
      _client = _factory.CreateClient();
    }
    public void Dispose()
    {
      //_client.Dispose();
      //_factory.OutputHelper = null;
      //_factory.Dispose();
    }

    [Fact(DisplayName = "GET Health")]
    public async Task Health()
    {
      var respObj = await _client.GetFromJsonAsync<object>("actuator/health");
      Assert.NotNull(respObj);
    }
    [Fact(DisplayName = "GET pet")]
    public async Task FindPet() {
      var vets = await _client.GetFromJsonAsync<Vet[]>($"vets");

      Assert.NotNull(vets);
      Assert.Equal(vets.Count(), Fill.Vets.Count());
    }
  }
}
