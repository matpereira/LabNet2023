using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poo.Net
{
    internal class Taxi : TransportePublico
    {
        public Taxi(int cantPasajeros) : base(cantPasajeros)
        {


        }

        public override string Avanzar()
        {
            return $"Taxi avanzando";
        }


        public override string Detenerse()
        {
            return $"Taxi Detenido";
        }
    }
}
