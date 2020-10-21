using System;
using System.Globalization;
using spring_petclinic_vets_api.DTOs;

namespace spring_petclinic_vets_api.Data
{
  internal static class Fill
  {
    public static Vet[] Vets => new[]{
      new Vet(){
        Id = 1,
        FirstName = "James",
        LastName = "Carter"
      },
      new Vet(){
        Id = 2,
        FirstName = "Helen",
        LastName = "Leary"
      },
      new Vet(){
        Id = 3,
        FirstName = "Linda",
        LastName = "Douglas"
      },
      new Vet(){
        Id = 4,
        FirstName = "Rafael",
        LastName = "Ortega"
      },
      new Vet(){
        Id = 5,
        FirstName = "Henry",
        LastName = "Stevens"
      },
      new Vet(){
        Id = 6,
        FirstName = "Sharon",
        LastName = "Jenkins"
      }
    };
    public static Specialty[] Specialties => new[]{
      new Specialty(){
        Id=1,
        Name = "radiology"
      },
      new Specialty(){
        Id=2,
        Name = "surgery"
      },
      new Specialty(){
        Id=3,
        Name = "dentistry"
      }
    };
    public static VetSpecialty[] VetSpecialties => new[]{
      new VetSpecialty(){
        VetId = 2,
        SpecialtyId = 1
      },
      new VetSpecialty(){
        VetId = 3,
        SpecialtyId = 2
      },
      new VetSpecialty(){
        VetId = 3,
        SpecialtyId = 3
      },
     new VetSpecialty(){
        VetId = 4,
        SpecialtyId = 2
      },
      new VetSpecialty(){
        VetId = 5,
        SpecialtyId = 1
      }
    };
  }
}
