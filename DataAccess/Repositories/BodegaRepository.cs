using Sinvex.DataAccess.Data;
using Sinvex.DataAccess.Repositories.IRepositories;
using Sinvex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinvex.DataAccess.Repositories
{
    public class BodegaRepository : Repository<Bodega>, IBodegaRepository
    {
        private readonly ApplicationDbContext _context;
        public BodegaRepository(ApplicationDbContext context) : base(context)
        {
            _context = context; 
        }

        public void Update(Bodega bodega)
        {
            var bodegaDb = _context.Bodegas.FirstOrDefault(x => x.Id == bodega.Id);
            if(bodegaDb != null)
            {
                bodegaDb.Nombre = bodega.Nombre;
                bodegaDb.Descripcion = bodega.Descripcion;
                bodegaDb.Estado = bodega.Estado;

                _context.SaveChanges();
            }
        }
    }
}
