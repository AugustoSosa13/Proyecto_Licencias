using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_Final.Models.Dtos;
using Proyecto_Final.Models.Entities;
using Proyecto_Final.Models.Request;
using Proyecto_Final.Models.Responses;
using Proyecto_Final.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_Final.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LicenciasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LicenciasController(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Devuelve un listado de todas las licencias.
        /// </summary>
        /// <remarks>
        /// Ejemplo de petición:
        ///
        /// GET /api/licencias
        ///
        /// Ejemplo de respuesta exitosa:
        /// {
        ///   "codigo": 200,
        ///   "mensaje": "Listado obtenido correctamente",
        ///   "contenido": [
        ///     {
        ///       "id": 1,
        ///       "dni": "12345678",
        ///       "tipoLicencia": "Ordinaria",
        ///       "provincia": "Chaco",
        ///       "localidad": "Resistencia",
        ///       "direccion": "Av. MOlienda 200",
        ///       "ordenDelDia": "OD123456",
        ///       "fechaInicio": "2025-09-11",
        ///       "fechaFin": "2025-09-20"
        ///     }
        ///   ]
        /// }
        /// </remarks>
        /// <response code="200">Respuesta exitosa.</response>
        /// <response code="404">No se encontraron licencias.</response>
        /// <response code="500">Error interno del servidor.</response>
        /// <returns>Lista de licencias existentes.</returns>
        [HttpGet]

        //GETPOINT GET
        public async Task<ActionResult<Envelope<IEnumerable<LicenciaDto>>>> GetLicencias()
        {
            var licencias = await _context.Licencias
                .Select(l => new LicenciaDto
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
                })
                .ToListAsync();

            if (!licencias.Any())
            {
                return NotFound(new Envelope<IEnumerable<LicenciaDto>>
                {
                    Exito = false,
                    Codigo = CodigoDeRespuesta.NoEncontrado,
                    Mensaje = "No hay licencias cargadas",
                    Datos = null
                });
            }

            return Ok(new Envelope<IEnumerable<LicenciaDto>>
            {
                Exito = true,
                Codigo = CodigoDeRespuesta.Exito,
                Mensaje = "Listado obtenido correctamente",
                Datos = licencias
            });
        }

        /// <summary>
        /// Crea una nueva licencia.
        /// </summary>
        /// <remarks>
        /// Ejemplo de petición:
        ///
        /// POST /api/licencias
        /// {
        ///   "dni": "12345678",
        ///   "fechaInicio": "2025-09-11",
        ///   "fechaFin": "2025-09-20",
        ///   "tipoLicencia": "Ordinaria",
        ///   "provincia": "Chaco",
        ///   "localidad": "Resistencia",
        ///   "direccion": "Av. Molienda 200",
        ///   "ordenDelDia": "OD123456"
        /// }
        ///
        /// </remarks>
        /// <response code="200">Licencia creada correctamente.</response>
        /// <response code="400">Datos inválidos.</response>
        /// <response code="500">Error interno del servidor.</response>
        /// <returns>Mensaje de confirmación.</returns>
        [HttpPost]

        //GETPOINT POST
        public async Task<ActionResult<Envelope<string>>> CrearLicencia(CrearLicenciaRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new Envelope<string>
                {
                    Exito = false,
                    Codigo = CodigoDeRespuesta.ErrorValidacion,
                    Mensaje = "Datos inválidos",
                    Datos = null
                });
            }

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

            _context.Licencias.Add(licencia);
            await _context.SaveChangesAsync();

            return Ok(new Envelope<string>
            {
                Exito = true,
                Codigo = CodigoDeRespuesta.Exito,
                Mensaje = "Licencia creada correctamente",
                Datos = null
            });
        }

        /// <summary>
        /// Actualiza una licencia existente.
        /// </summary>
        /// <remarks>
        /// Ejemplo de petición:
        ///
        /// PUT /api/licencias
        /// {
        ///   "id": 1,
        ///   "dni": "12345678",
        ///   "fechaInicio": "2025-09-15",
        ///   "fechaFin": "2025-09-25",
        ///   "tipoLicencia": "Extraordinaria",
        ///   "provincia": "Chaco",
        ///   "localidad": "Resistencia",
        ///   "direccion": "Av. Molienda 200",
        ///   "ordenDelDia": "OD654321"
        /// }
        ///
        /// </remarks>
        /// <response code="200">Licencia actualizada correctamente.</response>
        /// <response code="400">Datos inválidos.</response>
        /// <response code="404">Licencia no encontrada.</response>
        /// <response code="500">Error interno del servidor.</response>
        /// <returns>Mensaje de confirmación.</returns>
        [HttpPut]

        //GETPOINT PUT
        public async Task<ActionResult<Envelope<string>>> ActualizarLicencia(ActualizarLicenciaRequest request)
        {
            var licencia = await _context.Licencias.FindAsync(request.Id);
            if (licencia == null)
            {
                return NotFound(new Envelope<string>
                {
                    Exito = false,
                    Codigo = CodigoDeRespuesta.NoEncontrado,
                    Mensaje = "Licencia no encontrada",
                    Datos = null
                });
            }

            licencia.Dni = request.Dni;
            licencia.FechaInicio = request.FechaInicio;
            licencia.FechaFin = request.FechaFin;
            licencia.TipoLicencia = request.TipoLicencia;
            licencia.Provincia = request.Provincia;
            licencia.Localidad = request.Localidad;
            licencia.Direccion = request.Direccion;
            licencia.OrdenDelDia = request.OrdenDelDia;

            await _context.SaveChangesAsync();

            return Ok(new Envelope<string>
            {
                Exito = true,
                Codigo = CodigoDeRespuesta.Exito,
                Mensaje = "Licencia actualizada correctamente",
                Datos = null
            });
        }

        /// <summary>
        /// Elimina una licencia por Id.
        /// </summary>
        /// <remarks>
        /// Ejemplo de petición:
        ///
        /// DELETE /api/licencias/1
        ///
        /// </remarks>
        /// <response code="200">Licencia eliminada correctamente.</response>
        /// <response code="404">Licencia no encontrada.</response>
        /// <response code="500">Error interno del servidor.</response>
        /// <returns>Mensaje de confirmación.</returns>
        [HttpDelete("{id}")]

        //GETPOINT DELETE
        public async Task<ActionResult<Envelope<string>>> EliminarLicencia(int id)
        {
            var licencia = await _context.Licencias.FindAsync(id);
            if (licencia == null)
            {
                return NotFound(new Envelope<string>
                {
                    Exito = false,
                    Codigo = CodigoDeRespuesta.NoEncontrado,
                    Mensaje = "Licencia no encontrada",
                    Datos = null
                });
            }

            _context.Licencias.Remove(licencia);
            await _context.SaveChangesAsync();

            return Ok(new Envelope<string>
            {
                Exito = true,
                Codigo = CodigoDeRespuesta.Exito,
                Mensaje = "Licencia eliminada correctamente",
                Datos = null
            });
        }
    }
}
