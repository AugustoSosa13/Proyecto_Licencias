//Sirve para devolver información al frontend

namespace Proyecto_Final.Models.Dtos
{
    public class LicenciaDto
    {
        public int Id { get; set; }
        public string Dni { get; set; }
        public string TipoLicencia { get; set; }
        public string Provincia { get; set; }
        public string Localidad { get; set; }
        public string Direccion { get; set; }
        public string OrdenDelDia { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
    }
}
