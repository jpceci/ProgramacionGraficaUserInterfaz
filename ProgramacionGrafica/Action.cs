using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ProgramacionGrafica
{
    class Action
    {
        public string keyObjeto;
        public List<Convert> listaDeConversiones;

        public Action(string keyObjeto, List<Convert> listaDeConversiones)
        {
            this.keyObjeto = keyObjeto;
            this.listaDeConversiones = listaDeConversiones; 
        }

      
    }
}
