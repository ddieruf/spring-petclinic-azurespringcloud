using System;
using System.Collections.Generic;
using System.Linq;

namespace spring_petclinic_customers_api.DTOs
{
  public partial class Owner
  {
    public Owner()
    {
      Pets = new HashSet<Pet>();
    }

    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string Telephone { get; set; }

    public virtual ICollection<Pet> Pets { get; set; }
    //{
    //  get { return Pets.OrderByDescending(q => q.Name).ToList(); }
    //  set { Pets = value;  }
    //}

    public void AddPet(Pet pet)
    {
      Pets.Add(pet);
      pet.Owner = this;
    }

    public override string ToString()
    {
      return $@"id:{Id},
  lastName:{LastName},
  firstName:{FirstName},
  address:{Address},
  city:{City},
  telephone:{Telephone}";
    }
  }
}
