//Para cuando algo no se encuentra

using System;

namespace Proyecto_Final.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        {
        }
    }
}
