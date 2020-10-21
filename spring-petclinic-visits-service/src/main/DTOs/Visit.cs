using System;
using System.Text.Json.Serialization;

namespace spring_petclinic_visits_api.DTOs
{
  public partial class Visit {
    public int Id { get; set; }
    public int PetId { get; set; }
    [JsonConverter(typeof(DateTimeConverter))]
    public DateTime? VisitDate { get; set; }
    public string Description { get; set; }
  }
}
