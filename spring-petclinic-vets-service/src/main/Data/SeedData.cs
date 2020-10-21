using System.Threading;

namespace spring_petclinic_vets_api.Data
{
  internal static class SeedData
  {
  public static async void SeedAll(this VetsContext dbContext,
			bool ensureDelete = false,
			CancellationToken cancellationToken = default)
		{
			if(ensureDelete)
				dbContext.Database.EnsureDeleted();

			dbContext.Database.EnsureCreated();

      foreach (var vet in Fill.Vets)
        await dbContext.AddAsync(vet, cancellationToken);

      foreach (var speciality in Fill.Specialties)
        await dbContext.AddAsync(speciality, cancellationToken);

      foreach (var vetSpecialty in Fill.VetSpecialties)
        await dbContext.AddAsync(vetSpecialty, cancellationToken);

			await dbContext.SaveChangesAsync(cancellationToken);
		}
  }
}
