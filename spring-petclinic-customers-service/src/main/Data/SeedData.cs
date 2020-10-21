using System.Threading;

namespace spring_petclinic_customers_api.Data
{
  internal static class SeedData
  {
  public static async void SeedAll(this CustomersContext dbContext,
			bool ensureDelete = false,
			CancellationToken cancellationToken = default)
		{
			if(ensureDelete)
				dbContext.Database.EnsureDeleted();

			dbContext.Database.EnsureCreated();

      foreach (var petType in Fill.PetTypes)
        await dbContext.AddAsync(petType, cancellationToken);

      foreach (var owner in Fill.Owners)
        await dbContext.AddAsync(owner, cancellationToken);

      foreach (var pet in Fill.Pets)
        await dbContext.AddAsync(pet, cancellationToken);

			await dbContext.SaveChangesAsync(cancellationToken);
		}
  }
}
