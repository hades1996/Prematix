using prematix.Web.Data.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prematix.Web.Data
{
    public class Repository : IRepository
    {
        private readonly DataContext context;

        public Repository(DataContext context)
        {
            this.context = context;
        }

        public IEnumerable<Pediatra> GetPediatras()
        {
            return this.context.Pediatras.OrderBy(p => p.Name);
        }

        public Pediatra GetPediatra(int id)
        {
            return this.context.Pediatras.Find(id);
        }

        public void AddPediatra(Pediatra pediatra)
        {
            this.context.Pediatras.Add(pediatra);
        }

        public void UpdatePediatra(Pediatra pediatra)
        {
            this.context.Update(pediatra);
        }

        public void RemovePediatra(Pediatra pediatra)
        {
            this.context.Pediatras.Remove(pediatra);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await this.context.SaveChangesAsync() > 0;
        }

        public bool PediatraExists(int id)
        {
            return this.context.Pediatras.Any(p => p.Id == id);
        }

    }
}
