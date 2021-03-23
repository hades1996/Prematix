using prematix.Web.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace prematix.Web.Data
{
    public interface IRepository
    {
        void AddPediatra(Pediatra pediatra);

        Pediatra GetPediatra(int id);

        IEnumerable<Pediatra> GetPediatras();

        bool PediatraExists(int id);

        void RemovePediatra(Pediatra pediatra);

        Task<bool> SaveAllAsync();

        void UpdatePediatra(Pediatra pediatra);

    }
}