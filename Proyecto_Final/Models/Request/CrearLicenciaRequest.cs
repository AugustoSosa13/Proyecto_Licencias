//Este modelo representa el cuerpo del POST cuando se crea una licencia.

using System;
using System.ComponentModel.DataAnnotations;
using Proyecto_Final.Models.Enums;

namespace Proyecto_Final.Models.Request
{
    public class CrearLicenciaRequest
    {
        [Required(ErrorMessage = "El DNI es obligatorio.")]
        [StringLength(9, MinimumLength = 8, ErrorMessage = "El DNI debe tener entre 8 y 9 caracteres.")]
        public string Dni { get; set; }

        [Required(ErrorMessage = "La fecha de inicio es obligatoria.")]
        public DateTime FechaInicio { get; set; }

        [Required(ErrorMessage = "La fecha de fin es obligatoria.")]
        public DateTime FechaFin { get; set; }

        [Required(ErrorMessage = "El tipo de licencia es obligatorio.")]
        public TipoLicencia TipoLicencia { get; set; }

        [Required(ErrorMessage = "La provincia es obligatoria.")]
        public string Provincia { get; set; }

        [Required(ErrorMessage = "La localidad es obligatoria.")]
        public string Localidad { get; set; }

        [Required(ErrorMessage = "La dirección es obligatoria.")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "La Orden del Día es obligatoria.")]
        [StringLength(10, MinimumLength = 6, ErrorMessage = "La Orden del Día debe tener entre 6 y 10 caracteres.")]
        public string OrdenDelDia { get; set; }
    }
}
