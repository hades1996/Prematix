namespace prematix.Web.Data
{
    using Entities;

    public class PadreRepository : GenericRepository<Padre>, IPadreRepository
    {
        public PadreRepository(DataContext context) : base(context)
        {
        }
    }

}
