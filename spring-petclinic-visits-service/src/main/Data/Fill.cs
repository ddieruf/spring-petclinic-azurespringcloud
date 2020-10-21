using System;
using System.Globalization;
using spring_petclinic_visits_api.DTOs;

namespace spring_petclinic_visits_api.Data
{
  internal static class Fill
  {
    public static Visit[] Visits => new[]{
      new Visit(){
        Id = 1,
        PetId = 7,
        VisitDate = DateTime.ParseExact("2013-01-01", "yyyy-MM-dd", CultureInfo.InvariantCulture),
        Description = "rabies shot"
      },
      new Visit(){
        Id = 2,
        PetId = 8,
        VisitDate = DateTime.ParseExact("2013-01-02", "yyyy-MM-dd", CultureInfo.InvariantCulture),
        Description = "rabies shot"
      },
      new Visit(){
        Id = 3,
        PetId = 8,
        VisitDate = DateTime.ParseExact("2013-01-03", "yyyy-MM-dd", CultureInfo.InvariantCulture),
        Description = "neutered"
      },
      new Visit(){
        Id = 4,
        PetId = 7,
        VisitDate = DateTime.ParseExact("2013-01-04", "yyyy-MM-dd", CultureInfo.InvariantCulture),
        Description = "spayed"
      }
    };
  }
}
