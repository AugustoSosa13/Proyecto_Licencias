//Para cuando falta un campo obligatorio.

using System;

namespace Proyecto_Final.Exceptions
{
    public class CampoObligatorioException : Exception
    {
        public CampoObligatorioException(string campo)
            : base($"El campo '{campo}' es obligatorio y no puede estar vacío.")
        {
        }
    }
}
