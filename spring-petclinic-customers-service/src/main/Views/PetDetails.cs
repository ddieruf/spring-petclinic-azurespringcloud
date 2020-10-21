using spring_petclinic_customers_api.DTOs;
using System;
using System.Text.Json.Serialization;

namespace spring_petclinic_customers_api.Views
{
  
  public class PetDetails
  {
    public int Id { get; set; }

    public string Name { get; set; }

    public string Owner { get; set; }

    [JsonConverter(typeof(DateTimeConverter))]
    public DateTime? BirthDate{ get; set; }

    public PetType PetType { get; set; }

    public PetDetails() { }
    public PetDetails(int id, string name, string owner, DateTime? birthDate, PetType petType)
    {
      this.Id = id;
      this.Name = name;
      this.Owner = owner;
      this.BirthDate = birthDate;
      this.PetType = petType;
    }
    public PetDetails(Pet pet){
      Id = pet.Id;
      Name = pet.Name;
      Owner = pet.Owner?.FirstName + " " + pet.Owner?.LastName;
      BirthDate = pet.BirthDate;
      PetType = pet.PetType;
    }
  }
}
