using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej4CustomException
{
    internal class CustomException: Exception
    {

        public CustomException(string mensajeCustom) : base($"Mensaje de la excepcion: {mensajeCustom}")
        {
        }

    }
}
