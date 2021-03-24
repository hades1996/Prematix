namespace prematix.Web.Data
{
	using Entities;

	public class PediatraRepository : GenericRepository<Pediatra>, IPediatraRepository
	{
		public PediatraRepository(DataContext context) : base(context)
		{
		}
	}


}
