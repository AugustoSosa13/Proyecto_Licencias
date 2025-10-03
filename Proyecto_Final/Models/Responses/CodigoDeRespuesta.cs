//Enum con los resultados estándar (200, 400, 404, 500)

namespace Proyecto_Final.Models.Responses
{
    public enum CodigoDeRespuesta
    {
        Exito = 200,
        ErrorValidacion = 400,
        NoEncontrado = 404,
        ErrorServidor = 500
    }
}
