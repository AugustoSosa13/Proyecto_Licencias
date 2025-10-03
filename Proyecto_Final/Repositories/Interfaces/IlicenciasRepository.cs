//Extiende el IGenericRepository y agrega un método personalizado: buscar licencias por DNI.

using Proyecto_Final.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proyecto_Final.Repositories.Interfaces
{
    public interface ILicenciaRepository : IGenericRepository<SubOficialLicencia>
    {
        Task<IEnumerable<SubOficialLicencia>> GetByDniAsync(string dni);
    }
}
