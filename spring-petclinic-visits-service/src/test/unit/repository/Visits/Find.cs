using System;
using Xunit;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using spring_petclinic_visits_api.Data;

namespace spring_petclinic_visits_unit_test.Repository.Pets
{
  [Collection("Visits Test Collection")]
  public class Find
  {
    private readonly spring_petclinic_visits_api.Repository.IVisits _visitsRepo;

    public Find(VisitsRepo visitsRepo)
    {
      _visitsRepo = visitsRepo.Instance;
    }

    #region Test Collection Values
    public static IEnumerable<object[]> ValidIdValues() {
      return new List<object[]> {
        new object[] { Fill.Visits.First().PetId }
      };
    }
    public static IEnumerable<object[]> InvalidIdValues() {

      return new List<object[]> {
        new object[] { default },
        new object[] { null },
        new object[] { -1 },
        new object[] { 0 }
      };
    }
    #endregion

    [Theory(DisplayName = "Find all visits by invalid petId")]
    [MemberData(nameof(InvalidIdValues))]
    internal async Task FindByPetId_InvalidIds(int petId)
    {
      var visits = await _visitsRepo.FindByPetId(petId, default);

      Assert.Null(visits);
    }
    [Theory(DisplayName = "Find all visits by valid petId")]
    [MemberData(nameof(ValidIdValues))]
    internal async Task FindByPetId_ValidIds(int petId) {
      var visits = await _visitsRepo.FindByPetId(petId, default);

      Assert.NotNull(visits);
      Assert.Equal(Fill.Visits.Where(q => q.PetId == petId).Count(), visits.Count());
    }
  }
}
