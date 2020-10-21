using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace spring_petclinic_customers_api.DTOs
{
  public partial class Pet
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime? BirthDate { get; set; }
    public int TypeId { get; set; }
    public int OwnerId { get; set; }

    [JsonIgnore]
    public virtual Owner Owner { get; set; }
    [JsonIgnore]
    public virtual PetType PetType { get; set; }
    
    public override string ToString()
    {
      return $@"id:{this.Id},
  name: {this.Name},
  birthDate: {this.BirthDate},
  type: {this.PetType},
  ownerFirstname: {this.Owner?.FirstName},
  ownerLastname: {this.Owner?.LastName}";
    }
  }
}
