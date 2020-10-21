using System;
using System.Collections.Generic;

namespace spring_petclinic_customers_api.DTOs
{
    public partial class PetType
    {
        public PetType()
        {
            //Pets = new HashSet<Pet>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

       // public virtual ICollection<Pet> Pets { get; set; }
    }
}
