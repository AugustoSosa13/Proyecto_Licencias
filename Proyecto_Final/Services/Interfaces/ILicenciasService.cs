//define métodos de negocio

using Proyecto_Final.Models.Dtos;
using Proyecto_Final.Models.Request;
using Proyecto_Final.Models.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proyecto_Final.Services.Interfaces
{
    public interface ILicenciaService
    {
        Task<Envelope<IEnumerable<LicenciaDto>>> GetAllAsync();
        Task<Envelope<string>> CrearAsync(CrearLicenciaRequest request);
        Task<Envelope<string>> ActualizarAsync(ActualizarLicenciaRequest request);
        Task<Envelope<string>> EliminarAsync(int id);
    }
}
