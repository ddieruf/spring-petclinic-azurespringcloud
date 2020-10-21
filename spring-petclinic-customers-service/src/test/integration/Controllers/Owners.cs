using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using spring_petclinic_customers_api;
using spring_petclinic_customers_api.DTOs;
using System.Linq;
using spring_petclinic_customers_api.Data;

namespace spring_petclinic_customers_integration_test.Controllers
{
  [Collection("Owners API Test Collection")]
  public class Owners : IClassFixture<CustomersAppFactory<Startup>>, IDisposable
  {
    private readonly HttpClient _client;
    private readonly CustomersAppFactory<Startup> _factory;

    public Owners(CustomersAppFactory<Startup> factory, ITestOutputHelper outputHelper)
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
    [Fact(DisplayName = "GET all owners")]
    public async Task FindAll() {
      var owners = await _client.GetFromJsonAsync<Owner[]>("owners");

      Assert.NotNull(owners);
      Assert.True(owners.Count() >= Fill.Owners.Count());//POST test could get run before this
    }
    [Fact(DisplayName = "GET owner")]
    public async Task FindOwner() {
      var o = Fill.Owners.First();

      var owner = await _client.GetFromJsonAsync<Owner>($"owners/{o.Id}");

      Assert.NotNull(owner);
      Assert.Equal(owner.Id, o.Id);
    }
    [Fact(DisplayName = "POST new owner")]
    public async Task CreateOwner() {
       var newOwner = new Owner() {
         Id = 87,
         FirstName = "Some",
         LastName = "One",
         Address = "123 Street Rd",
         City = "City",
         Telephone = "45645645655",
       };

      var resp = await _client.PostAsJsonAsync($"owners", newOwner);

      Assert.True(resp.IsSuccessStatusCode);

      var owner = await resp.Content.ReadFromJsonAsync<Owner>();

      Assert.NotNull(owner);
      Assert.Equal(newOwner.Id, owner.Id);
    }
    [Fact(DisplayName = "PUT existing owner")]
    public async Task ProcessUpdateForm() {
      var owner = Fill.Owners.First();

      owner.FirstName = "aaaaaa";

      var resp = await _client.PutAsJsonAsync($"owners/{owner.Id}", owner);

      Assert.True(resp.IsSuccessStatusCode);
    }
  }
}
