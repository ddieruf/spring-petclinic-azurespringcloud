using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace spring_petclinic_vets_api.DTOs
{
    public partial class VetSpecialty
    {
        public int VetSpecialtyId { get; set; }
        public int VetId { get; set; }
        public int SpecialtyId { get; set; }

        public virtual Specialty Specialty { get; set; }
        public virtual Vet Vet { get; set; }
    }
}
