//Hereda de GenericRepository con método específico para la lógica de licencias

using Microsoft.EntityFrameworkCore;
using Proyecto_Final.Models.Entities;
using Proyecto_Final.Persistence;
using Proyecto_Final.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_Final.Repositories.Implementations
{
    public class LicenciaRepository : GenericRepository<SubOficialLicencia>, ILicenciaRepository
    {
        private readonly AppDbContext _context;

        public LicenciaRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SubOficialLicencia>> GetByDniAsync(string dni)
        {
            return await _context.Licencias
                .Where(l => l.Dni == dni)
                .ToListAsync();
        }
    }
}
