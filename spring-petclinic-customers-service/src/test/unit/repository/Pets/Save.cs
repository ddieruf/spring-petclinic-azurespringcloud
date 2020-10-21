using System;
using Xunit;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using spring_petclinic_customers_api.Data;
using spring_petclinic_customers_api.Views;

namespace spring_petclinic_customers_unit_test.Repository.Pets
{
  [Collection("Pets Test Collection")]
  public class Save
  {
    private readonly spring_petclinic_customers_api.Repository.IPets _petsRepo;

    public Save(PetsRepo petsRepo)
    {
      _petsRepo = petsRepo.Instance;
    }

    #region Test Collection Values
    public static IEnumerable<object[]> InvalidSaveValues()
    {
      var ownerId = Fill.Owners.First().Id;
      var validRequest = new PetRequest(99, DateTime.Now, "A name", Fill.PetTypes.First().Id);
      var alreadyExists = new PetRequest(1, DateTime.Now, "A name", Fill.PetTypes.First().Id);
      var blankName = new PetRequest(98, DateTime.Now, "", Fill.PetTypes.First().Id);
      var nullName = new PetRequest(97, DateTime.Now, null, Fill.PetTypes.First().Id);
      var badPetType = new PetRequest(96, DateTime.Now, null, -1);

      return new List<object[]> {
        new object[] { -1, validRequest },
        /*new object[] { ownerId, alreadyExists },
        new object[] { ownerId, blankName },
        new object[] { ownerId, nullName },
        new object[] { ownerId, badPetType }*/
      };
    }
    public static IEnumerable<object[]> ValidSaveValues()
    {
      var ownerId = Fill.Owners.First().Id;

      return new List<object[]> {
        new object[] { ownerId, new PetRequest(95, DateTime.Now, "Harold", Fill.PetTypes.First().Id) },
        new object[] { ownerId, new PetRequest(94, null, "Henry1", Fill.PetTypes.Skip(1).First().Id) }
      };
    }
    #endregion

    [Theory(DisplayName = "Save pet with bad values")]
    [MemberData(nameof(InvalidSaveValues))]
    internal async Task Save_BadValues(int ownerId, PetRequest petReuqest)
    {
      try{
        await _petsRepo.Save(ownerId, petReuqest, default);
      }catch{
        return;
      }

      throw new Exception("Test returned unexpected value");
    }
    
    [Theory(DisplayName = "Save pet with good values")]
    [MemberData(nameof(ValidSaveValues))]
    internal async Task Save_GoodValues(int ownerId, PetRequest petReuqest)
    {
      var pet = await _petsRepo.Save(ownerId, petReuqest, default);

      Assert.NotNull(pet);
      Assert.Equal(ownerId, pet.Owner.Id);
    }
  }
}
