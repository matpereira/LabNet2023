using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej4CustomException
{
    internal class Logic
    {

        public static void ThrowCustomException()
        {
            throw new CustomException("Error de prueba custom");
        }
    }
}
