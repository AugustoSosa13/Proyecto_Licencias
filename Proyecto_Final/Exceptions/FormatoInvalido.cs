//Para cuando el dato está mal formado

using System;

namespace Proyecto_Final.Exceptions
{
    public class FormatoInvalidoException : Exception
    {
        public FormatoInvalidoException(string campo, string detalle)
            : base($"El campo '{campo}' tiene un formato inválido. {detalle}")
        {
        }
    }
}
