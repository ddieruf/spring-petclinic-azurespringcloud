using System;
using Xunit;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using spring_petclinic_customers_api.Data;
using spring_petclinic_customers_api.Views;
using spring_petclinic_customers_api.DTOs;

namespace spring_petclinic_customers_unit_test.Repository.Pets
{
  [Collection("Pets Test Collection")]
  public class Update
  {
    private readonly spring_petclinic_customers_api.Repository.IPets _petsRepo;

    public Update(PetsRepo petsRepo)
    {
      _petsRepo = petsRepo.Instance;
    }

    #region Test Collection Values
    public static IEnumerable<object[]> InvalidUpdateValues()
    {
      var validPet = Fill.Pets.First() ;

      var validRequest = new PetRequest(validPet.Id, DateTime.Now, "A name", Fill.PetTypes.First().Id);
      var blankName = new PetRequest(validPet.Id, DateTime.Now, "", Fill.PetTypes.First().Id);
      var nullName = new PetRequest(validPet.Id, DateTime.Now, null, Fill.PetTypes.First().Id);

      return new List<object[]> {
        new object[] { null, validRequest },
        //new object[] { validPet, blankName },
        //new object[] { validPet, nullName }
      };
    }
    public static IEnumerable<object[]> ValidUpdateValues()
    {
      var validPet = Fill.Pets.First(q => q.BirthDate.HasValue);
      var changeName = new PetRequest(validPet.Id, validPet.BirthDate, "A new name", validPet.TypeId);
      var changeBirthDate = new PetRequest(validPet.Id, validPet.BirthDate.Value.AddDays(2), validPet.Name, validPet.TypeId);
      var nullBirthDate = new PetRequest(validPet.Id, null, validPet.Name, validPet.TypeId);

      return new List<object[]> {
        new object[] { validPet, changeName },
        new object[] { validPet, changeBirthDate },
        //new object[] { validPet, nullBirthDate }
      };
    }
    #endregion

    [Theory(DisplayName = "Update pet with bad values")]
    [MemberData(nameof(InvalidUpdateValues))]
    internal async Task Update_BadValues(Pet pet, PetRequest petReuqest)
    {
      try{
        await _petsRepo.Update(pet.Id, petReuqest, default);
      }catch{
        return;
      }

      throw new Exception("Test returned unexpected value");
    }
     
    [Theory(DisplayName = "Update pet with good values")]
    [MemberData(nameof(ValidUpdateValues))]
    internal async Task Update_GoodValues(Pet pet, PetRequest petReuqest)
    {
      var updatedPet = await _petsRepo.Update(pet.Id, petReuqest, default);

      Assert.NotNull(updatedPet);
      Assert.Equal(petReuqest.Name, updatedPet.Name);
      Assert.Equal(petReuqest.BirthDate, updatedPet.BirthDate);
    }
  }
}
