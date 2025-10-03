//para que todas las respuestas de la API tengan el mismo formato.


namespace Proyecto_Final.Models.Responses
{
    public class Envelope<T>
    {
        public bool Exito { get; set; }
        public CodigoDeRespuesta Codigo { get; set; }
        public string Mensaje { get; set; }
        public T Datos { get; set; }
    }
}
