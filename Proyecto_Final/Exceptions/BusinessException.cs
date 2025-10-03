//Para errores de reglas de negocio

using System;

namespace Proyecto_Final.Exceptions
{
    public class BusinessException : Exception
    {
        public BusinessException(string message) : base(message)
        {
        }
    }
}
