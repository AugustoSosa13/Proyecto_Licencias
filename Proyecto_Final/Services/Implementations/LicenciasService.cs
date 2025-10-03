//Aplica reglas, maneja mensajes de error/exito, etc.

using Proyecto_Final.Models.Dtos;
using Proyecto_Final.Models.Entities;
using Proyecto_Final.Models.Request;
using Proyecto_Final.Models.Responses;
using Proyecto_Final.Repositories.Interfaces;
using Proyecto_Final.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_Final.Services.Implementations
{
    public class LicenciaService : ILicenciaService
    {
        private readonly ILicenciaRepository _licenciaRepository;

        public LicenciaService(ILicenciaRepository licenciaRepository)
        {
            _licenciaRepository = licenciaRepository;
        }

        public async Task<Envelope<IEnumerable<LicenciaDto>>> GetAllAsync()
        {
            var licencias = await _licenciaRepository.GetAllAsync();

            var lista = licencias.Select(l => new LicenciaDto
            {
                Id = l.Id,
                Dni = l.Dni,
                TipoLicencia = l.TipoLicencia.ToString(),
                Provincia = l.Provincia,
                Localidad = l.Localidad,
                Direccion = l.Direccion,
                OrdenDelDia = l.OrdenDelDia,
                FechaInicio = l.FechaInicio.ToShortDateString(),
                FechaFin = l.FechaFin.ToShortDateString()
            });

            return new Envelope<IEnumerable<LicenciaDto>>
            {
                Exito = true,
                Codigo = CodigoDeRespuesta.Exito,
                Mensaje = "Listado obtenido correctamente",
                Datos = lista
            };
        }

        public async Task<Envelope<string>> CrearAsync(CrearLicenciaRequest request)
        {
            var licencia = new SubOficialLicencia
            {
                Dni = request.Dni,
                FechaInicio = request.FechaInicio,
                FechaFin = request.FechaFin,
                TipoLicencia = request.TipoLicencia,
                Provincia = request.Provincia,
                Localidad = request.Localidad,
                Direccion = request.Direccion,
                OrdenDelDia = request.OrdenDelDia
            };

            await _licenciaRepository.AddAsync(licencia);
            await _licenciaRepository.SaveAsync();

            return new Envelope<string>
            {
                Exito = true,
                Codigo = CodigoDeRespuesta.Exito,
                Mensaje = "Licencia creada correctamente",
                Datos = null
            };
        }

        public async Task<Envelope<string>> ActualizarAsync(ActualizarLicenciaRequest request)
        {
            var licencia = await _licenciaRepository.GetByIdAsync(request.Id);
            if (licencia == null)
            {
                return new Envelope<string>
                {
                    Exito = false,
                    Codigo = CodigoDeRespuesta.NoEncontrado,
                    Mensaje = "Licencia no encontrada",
                    Datos = null
                };
            }

            licencia.Dni = request.Dni;
            licencia.FechaInicio = request.FechaInicio;
            licencia.FechaFin = request.FechaFin;
            licencia.TipoLicencia = request.TipoLicencia;
            licencia.Provincia = request.Provincia;
            licencia.Localidad = request.Localidad;
            licencia.Direccion = request.Direccion;
            licencia.OrdenDelDia = request.OrdenDelDia;

            _licenciaRepository.Update(licencia);
            await _licenciaRepository.SaveAsync();

            return new Envelope<string>
            {
                Exito = true,
                Codigo = CodigoDeRespuesta.Exito,
                Mensaje = "Licencia actualizada correctamente",
                Datos = null
            };
        }

        public async Task<Envelope<string>> EliminarAsync(int id)
        {
            var licencia = await _licenciaRepository.GetByIdAsync(id);
            if (licencia == null)
            {
                return new Envelope<string>
                {
                    Exito = false,
                    Codigo = CodigoDeRespuesta.NoEncontrado,
                    Mensaje = "Licencia no encontrada",
                    Datos = null
                };
            }

            _licenciaRepository.Delete(licencia);
            await _licenciaRepository.SaveAsync();

            return new Envelope<string>
            {
                Exito = true,
                Codigo = CodigoDeRespuesta.Exito,
                Mensaje = "Licencia eliminada correctamente",
                Datos = null
            };
        }
    }
}

