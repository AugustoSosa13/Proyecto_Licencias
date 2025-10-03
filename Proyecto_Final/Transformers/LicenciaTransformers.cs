//aplica el Patrón Adapter. Su función es convertir Entities ↔ DTOs ↔ Requests, para no repetir lógica de mapeo en cada capa.

using Proyecto_Final.Models.Dtos;
using Proyecto_Final.Models.Entities;
using Proyecto_Final.Models.Request;
using System.Collections.Generic;
using System.Linq;
using Proyecto_Final.Models.Enums;


namespace Proyecto_Final.Transformers
{
    public static class LicenciaTransformer
    {
        
        public static LicenciaDto ToDto(SubOficialLicencia entity)
        {
            if (entity == null) return null;

            return new LicenciaDto
            {
                Id = entity.Id,
                Dni = entity.Dni,
                TipoLicencia = entity.TipoLicencia.ToString(),
                Provincia = entity.Provincia,
                Localidad = entity.Localidad,
                Direccion = entity.Direccion,
                OrdenDelDia = entity.OrdenDelDia,
                FechaInicio = entity.FechaInicio.ToShortDateString(),
                FechaFin = entity.FechaFin.ToShortDateString()
            };
        }

        
        public static IEnumerable<LicenciaDto> ToDtoList(IEnumerable<SubOficialLicencia> entities)
        {
            return entities?.Select(e => ToDto(e)).ToList();
        }

        
        public static SubOficialLicencia ToEntity(CrearLicenciaRequest request)
        {
            if (request == null) return null;

            return new SubOficialLicencia
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
        }

        
        public static void UpdateEntity(SubOficialLicencia entity, ActualizarLicenciaRequest request)
        {
            if (entity == null || request == null) return;

            entity.Dni = request.Dni;
            entity.FechaInicio = request.FechaInicio;
            entity.FechaFin = request.FechaFin;
            entity.TipoLicencia = request.TipoLicencia;
            entity.Provincia = request.Provincia;
            entity.Localidad = request.Localidad;
            entity.Direccion = request.Direccion;
            entity.OrdenDelDia = request.OrdenDelDia;
        }
    }
}
