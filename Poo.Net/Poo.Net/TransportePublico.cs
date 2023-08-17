using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poo.Net
{
    public abstract class TransportePublico
    {
        public int cantPasajeros { get; set; }

        public TransportePublico (int cantPasajeros)
        {
            this.cantPasajeros = cantPasajeros;
        }

        public abstract string Avanzar();
        public abstract string Detenerse();
    }
}
