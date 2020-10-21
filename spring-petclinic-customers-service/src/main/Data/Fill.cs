using System;
using System.Globalization;
using spring_petclinic_customers_api.DTOs;

namespace spring_petclinic_customers_api.Data
{
  internal static class Fill
  {
    public static PetType[] PetTypes => new[]{
      new PetType(){
        Id = 1,
        Name = "cat"
      },
      new PetType(){
        Id = 2,
        Name = "dog"
      },
      new PetType(){
        Id = 3,
        Name = "lizard"
      },
      new PetType(){
        Id = 4,
        Name = "snake"
      },
      new PetType(){
        Id = 5,
        Name = "bird"
      },
      new PetType(){
        Id = 6,
        Name = "hamster"
      }
    };
    public static Owner[] Owners => new[]{
      new Owner(){
        Id=1,
        FirstName="George",
        LastName="Franklin",
        Address="110 W. Liberty St.",
        City = "Madison",
        Telephone = "6085551023",
      },
      new Owner(){
        Id=2,
        FirstName="Betty",
        LastName="Davis",
        Address="638 Cardinal Ave.",
        City = "Sun Prairie",
        Telephone = "6085551749",
      },
      new Owner(){
        Id=3,
        FirstName="Eduardo",
        LastName="Rodriquez",
        Address="2693 Commerce St.",
        City = "McFarland",
        Telephone = "6085558763",
      },
      new Owner(){
        Id=4,
        FirstName="Harold",
        LastName="Davis",
        Address="563 Friendly St.",
        City = "Windsor",
        Telephone = "6085553198",
      },
      new Owner(){
        Id=5,
        FirstName="Peter",
        LastName="McTavish",
        Address="2387 S. Fair Way",
        City = "Madison",
        Telephone = "6085552765",
      },
      new Owner(){
        Id=6,
        FirstName="Jean",
        LastName="Coleman",
        Address="105 N. Lake St.",
        City = "Monona",
        Telephone = "6085552654",
      },
      new Owner(){
        Id=7,
        FirstName="Jeff",
        LastName="Black",
        Address="1450 Oak Blvd.",
        City = "Monona",
        Telephone = "6085555387",
      },
      new Owner(){
        Id=8,
        FirstName="Maria",
        LastName="Escobito",
        Address="345 Maple St.",
        City = "Madison",
        Telephone = "6085557683",
      },
      new Owner(){
        Id=9,
        FirstName="David",
        LastName="Schroeder",
        Address="2749 Blackhawk Trail",
        City = "Madison",
        Telephone = "6085559435",
      },
      new Owner(){
        Id=10,
        FirstName="Carlos",
        LastName="Estaban",
        Address="2335 Independence La.",
        City = "Waunakee",
        Telephone = "6085555487",
      }
    };
    public static Pet[] Pets => new[]{
      new Pet(){
        Id=1,
        Name="Leo",
        BirthDate=DateTime.ParseExact("2010-09-07", "yyyy-MM-dd", CultureInfo.InvariantCulture),
        TypeId=1,
        OwnerId=1
      },
      new Pet(){
        Id=2,
        Name="Basil",
        BirthDate=DateTime.ParseExact("2012-08-06", "yyyy-MM-dd", CultureInfo.InvariantCulture),
        TypeId=2,
        OwnerId=3
      },
      new Pet(){
        Id=3,
        Name="Rosy",
        BirthDate=DateTime.ParseExact("2011-04-17", "yyyy-MM-dd", CultureInfo.InvariantCulture),
        TypeId=2,
        OwnerId=3
      },
      new Pet(){
        Id=4,
        Name="Jewel",
        BirthDate=DateTime.ParseExact("2010-03-07", "yyyy-MM-dd", CultureInfo.InvariantCulture),
        TypeId=2,
        OwnerId=3
      },
      new Pet(){
        Id=5,
        Name="Iggy",
        BirthDate=DateTime.ParseExact("2010-11-30", "yyyy-MM-dd", CultureInfo.InvariantCulture),
        TypeId=3,
        OwnerId=4
      },
      new Pet(){
        Id=6,
        Name="George",
        BirthDate=DateTime.ParseExact("2010-01-20", "yyyy-MM-dd", CultureInfo.InvariantCulture),
        TypeId=4,
        OwnerId=5
      },
      new Pet(){
        Id=7,
        Name="Samantha",
        BirthDate=DateTime.ParseExact("2012-09-04", "yyyy-MM-dd", CultureInfo.InvariantCulture),
        TypeId=1,
        OwnerId=6
      },
      new Pet(){
        Id=8,
        Name="Max",
        BirthDate=DateTime.ParseExact("2012-09-04", "yyyy-MM-dd", CultureInfo.InvariantCulture),
        TypeId=1,
        OwnerId=6
      },
      new Pet(){
        Id=9,
        Name="Lucky",
        BirthDate=DateTime.ParseExact("2011-08-06", "yyyy-MM-dd", CultureInfo.InvariantCulture),
        TypeId=5,
        OwnerId=7
      },
      new Pet(){
        Id=10,
        Name="Mulligan",
        BirthDate=DateTime.ParseExact("2007-02-24", "yyyy-MM-dd", CultureInfo.InvariantCulture),
        TypeId=2,
        OwnerId=8
      },
      new Pet(){
        Id=11,
        Name="Freddy",
        BirthDate=DateTime.ParseExact("2010-03-09", "yyyy-MM-dd", CultureInfo.InvariantCulture),
        TypeId=5,
        OwnerId=9
      },
      new Pet(){
        Id=12,
        Name="Lucky",
        BirthDate=DateTime.ParseExact("2010-06-24", "yyyy-MM-dd", CultureInfo.InvariantCulture),
        TypeId=2,
        OwnerId=10
      },
      new Pet(){
        Id=13,
        Name="Sly",
        BirthDate=DateTime.ParseExact("2012-06-08", "yyyy-MM-dd", CultureInfo.InvariantCulture),
        TypeId=1,
        OwnerId=10
      }
    };
  }
}
