using System;
using System.Collections.Generic;
using System.Linq;

namespace spring_petclinic_vets_api.DTOs
{
    public partial class Vet
    {
      public Vet() {
        Specialties = new HashSet<Specialty>();
      }

      public int Id { get; set; }
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public virtual ICollection<Specialty> Specialties { get; set; }
    public int NrOfSpecialties => this.Specialties.Count();
  }
}
