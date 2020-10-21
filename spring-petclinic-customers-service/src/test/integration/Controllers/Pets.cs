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
using spring_petclinic_customers_api.Views;
using System.Globalization;

namespace spring_petclinic_customers_integration_test.Controllers
{
  [Collection("Pets API Test Collection")]
  public class Pets : IClassFixture<CustomersAppFactory<Startup>>, IDisposable
  {
    private readonly HttpClient _client;
    private readonly CustomersAppFactory<Startup> _factory;

    public Pets(CustomersAppFactory<Startup> factory, ITestOutputHelper outputHelper)
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
    [Fact(DisplayName = "GET pet types")]
    public async Task GetPetTypes() {
      var petTypes = await _client.GetFromJsonAsync<PetType[]>("petTypes");
      Assert.NotNull(petTypes);
      Assert.Equal(petTypes.Count(), Fill.PetTypes.Count());
    }
    [Fact(DisplayName = "GET pet")]
    public async Task FindPet() {
      var pet = Fill.Pets.First();

      var petDetails = await _client.GetFromJsonAsync<PetDetails>($"owners/pets/{pet.Id}");

      Assert.NotNull(petDetails);
      Assert.Equal(petDetails.Id, pet.Id);
    }
    [Fact(DisplayName = "POST new pet")]
    public async Task ProcessCreationForm() {
      var owner = Fill.Owners.First();

      var petReq = new PetRequest(
        52,
        DateTime.ParseExact("2012-09-07", "yyyy-MM-dd", CultureInfo.InvariantCulture),
        "Number 52",
        Fill.PetTypes.Skip(2).First().Id
      );

      var resp = await _client.PostAsJsonAsync($"owners/{owner.Id}/pets", petReq);

      Assert.True(resp.IsSuccessStatusCode);
    }
    [Fact(DisplayName = "PUT existing pet")]
    public async Task ProcessUpdateForm() {
      var pet = Fill.Pets.First();

      var petReq = new PetRequest(
        pet.Id,
        DateTime.ParseExact("2012-09-07", "yyyy-MM-dd", CultureInfo.InvariantCulture),
        "Updated",
        pet.TypeId
      );

      var resp = await _client.PutAsJsonAsync($"owners/pets/{pet.Id}", petReq);

      Assert.True(resp.IsSuccessStatusCode);
    }
  }
}
