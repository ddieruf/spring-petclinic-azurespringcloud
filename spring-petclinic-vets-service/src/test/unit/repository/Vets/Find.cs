using System;
using Xunit;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using spring_petclinic_vets_api.Data;

namespace spring_petclinic_vets_unit_test.Repository.Pets
{
  [Collection("Vets Test Collection")]
  public class Find
  {
    private readonly spring_petclinic_vets_api.Repository.IVets _vetsRepo;

    public Find(VetsRepo petsRepo)
    {
      _vetsRepo = petsRepo.Instance;
    }

    #region Test Collection Values
    #endregion

    [Fact(DisplayName = "Find all vets")]
    internal async Task FindPets()
    {
      var vets = await _vetsRepo.FindAll(default);

      Assert.NotNull(vets);
      Assert.Equal(Fill.Vets.Count(), vets.Count());

      foreach(var vet in vets){
        Assert.Equal(vet.Specialties.Count(), Fill.VetSpecialties.Where(q => q.VetId == vet.Id).Count());
      }
    }
  }
}
