using System;
using Xunit;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using spring_petclinic_visits_api.Data;
using spring_petclinic_visits_unit_test.Repository;
using spring_petclinic_visits_api.DTOs;
using System.Globalization;

namespace spring_petclinic_visits_unit_test.repository.Visits {
  [Collection("Visits Test Collection")]
  public class Save {
    private readonly spring_petclinic_visits_api.Repository.IVisits _visitsRepo;

    public Save(VisitsRepo visitsRepo) {
      _visitsRepo = visitsRepo.Instance;
    }

    #region Test Collection Values
    public static IEnumerable<object[]> InvalidSaveValues() {
      var petId = Fill.Visits.First().PetId;

      var alreadyExists = new Visit() {
        Id = Fill.Visits.First().Id,
        Description = "This is cool",
        PetId = petId,
        VisitDate = DateTime.Now
      };

      return new List<object[]> {
        new object[] { -1, alreadyExists },
        new object[] { petId, alreadyExists }
      };
    }
    public static IEnumerable<object[]> ValidSaveValues() {
      var petId = Fill.Visits.First().PetId;

      return new List<object[]> {
        new object[] { petId, new Visit() {
          Id = Fill.Visits.Count()+1,
          Description = "This is cool",
          PetId = petId,
          VisitDate = DateTime.Now
        }
       }
      };
    }
    #endregion

    [Theory(DisplayName = "Save visit with bad values")]
    [MemberData(nameof(InvalidSaveValues))]
    internal async Task Save_BadValues(int petId, Visit visit) {
      try {
        await _visitsRepo.Save(petId, visit, default);
      } catch {
        return;
      }

      throw new Exception("Test returned unexpected value");
    }

    [Theory(DisplayName = "Save visit with good values")]
    [MemberData(nameof(ValidSaveValues))]
    internal async Task Save_GoodValues(int petId, Visit visit) {
      var newVisit = await _visitsRepo.Save(petId, visit, default);

      Assert.NotNull(newVisit);
      Assert.Equal(petId, newVisit.PetId);
    }
  }
}
