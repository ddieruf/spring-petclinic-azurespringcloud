using System;
using System.Text.Json.Serialization;

namespace spring_petclinic_customers_api.Views
{
  public class PetRequest
  {
    public PetRequest() { }
    public PetRequest(int id, DateTime? birthDate, string name, int petTypeId){
      this.Id = id;
      this.BirthDate = birthDate;
      this.Name = name;
      this.PetTypeId = petTypeId;
    }
    public int Id { get; set; }

    [JsonConverter(typeof(DateTimeConverter))]
    public DateTime? BirthDate { get; set; }

    public string Name { get; set; }

    public int PetTypeId { get; set; }
  }
}
