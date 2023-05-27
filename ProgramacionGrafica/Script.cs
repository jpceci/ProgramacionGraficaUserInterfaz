using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

namespace ProgramacionGrafica
{
    class Script
    {
        public List<Action> listaDeAcciones;
        public Stage escenario;

        public Script(List<Action> listaDeAcciones, Stage escenario)
        {
            this.listaDeAcciones = listaDeAcciones;
            this.escenario = escenario;
        }
    }
}
