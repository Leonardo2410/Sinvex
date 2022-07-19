using Sinvex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinvex.DataAccess.Repositories.IRepositories
{
    public interface IBodegaRepository :IRepository<Bodega>
    {
        void Update(Bodega bodega);

    }
}
