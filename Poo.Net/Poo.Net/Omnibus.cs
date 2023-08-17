using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poo.Net
{
    internal class Omnibus : TransportePublico
    {

        public Omnibus(int cantPasajeros) : base(cantPasajeros) { }




        public override string Avanzar()
        {
            return $"Omnibus avanzando";
        }


        public override string Detenerse()
        {
            return $"Omnibus Detenido";
        }
    }
}
