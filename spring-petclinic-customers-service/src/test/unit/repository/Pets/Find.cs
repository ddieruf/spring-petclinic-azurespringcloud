using System;
using Xunit;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using spring_petclinic_customers_api.Data;

namespace spring_petclinic_customers_unit_test.Repository.Pets
{
  [Collection("Pets Test Collection")]
  public class Find
  {
    private readonly spring_petclinic_customers_api.Repository.IPets _petsRepo;

    public Find(PetsRepo petsRepo)
    {
      _petsRepo = petsRepo.Instance;
    }

    #region Test Collection Values
    public static IEnumerable<object[]> InvalidIdValues()
    {

      return new List<object[]> {
        new object[] { default },
        new object[] { null },
        new object[] { -1 },
        new object[] { 0 }
      };
    }
    public static IEnumerable<object[]> ValidPetTypeIds()
    {
      return new List<object[]> {
        new object[] { Fill.PetTypes.First().Id }
      };
    }
    public static IEnumerable<object[]> ValidPetIds()
    {
      return new List<object[]> {
        new object[] { Fill.Pets.First().Id }
      };
    }
    public static IEnumerable<object[]> ValidPageValues()
    {
      return new List<object[]> {
        new object[] { 0, 1 },
        new object[] { 0, 5 },
        new object[] { 1, 1 },
        new object[] { 3, 1 }
      };
    }

    #endregion

    [Fact(DisplayName = "Find all pet types")]
    internal async Task FindPetTypes(){
      var petTypes = await _petsRepo.FindPetTypes(default);

      Assert.NotNull(petTypes);
      Assert.Equal(Fill.PetTypes.Count(), petTypes.Count());
    }

    [Fact(DisplayName = "Find all pets")]
    internal async Task FindPets()
    {
      var pets = await _petsRepo.FindAll(default);

      Assert.NotNull(pets);
      Assert.Equal(Fill.Pets.Count(), pets.Count());
    }

    [Theory(DisplayName = "Find pet type by id with bad values")]
    [MemberData(nameof(InvalidIdValues))]
    internal async Task FindPetTypeById_BadValues(int id)
    {
      var petType = await _petsRepo.FindPetTypeById(id, default);

      Assert.Null(petType);
    }

    [Theory(DisplayName = "Find pet type by id with good values")]
    [MemberData(nameof(ValidPetTypeIds))]
    internal async Task FindPetTypeById_GoodValues(int id)
    {
      var petType = await _petsRepo.FindPetTypeById(id, default);

      Assert.NotNull(petType);
      Assert.Equal(id, petType.Id);
    }

    [Theory(DisplayName = "Find pet by id with bad values")]
    [MemberData(nameof(InvalidIdValues))]
    internal async Task FindPetById_BadValues(int id)
    {
      var petType = await _petsRepo.FindById(id, default);

      Assert.Null(petType);
    }

    [Theory(DisplayName = "Find pet by id with good values")]
    [MemberData(nameof(ValidPetIds))]
    internal async Task FindPetById_GoodValues(int id)
    {
      var petType = await _petsRepo.FindById(id, default);

      Assert.NotNull(petType);
      Assert.Equal(id, petType.Id);
    }

    [Theory(DisplayName = "Find all pets with good page values")]
    [MemberData(nameof(ValidPageValues))]
    internal async Task FindPetsWithPaging_GoodValues(int page, int pageSize)
    {
      var pets = await _petsRepo.FindAll(page, pageSize, default);

      Assert.NotNull(pets);
      Assert.Equal(pets.Count(), Fill.Pets.Skip(page * pageSize).Take(pageSize).Count());
    }
  }
}
