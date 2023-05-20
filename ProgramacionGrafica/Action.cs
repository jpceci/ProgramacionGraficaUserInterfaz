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
        public int x, y, z;
        public string transformacion;
        public int cantidadATransformar;
        public decimal diferencial;
        public long duracion;
        public int contador = 0;
        public long segundos = 0;
        public long tiempoInicio;

        public Action(string transformacion, int cantidadATransformar, int x, int y, int z, long duracion, long tiempoInicio)
        {
            this.transformacion = transformacion;
            this.cantidadATransformar = cantidadATransformar;
            this.x = x;
            this.y = y;
            this.z = z;
            this.duracion = duracion;
            this.tiempoInicio = tiempoInicio;
            segundos = this.duracion / 1000;
            diferencial = (decimal) this.cantidadATransformar/(24 * segundos);
        }

        public void RunAction(Object objeto)
        {
            segundos = this.duracion / 1000;
            while (contador < 24 * segundos)
            {
                
                switch (transformacion)
                {
                    case "Traslacion":
                        objeto.Translate((float) this.diferencial, this.x, this.y, this.z);
                        break;
                    case "Rotacion":
                        objeto.Rotate((float) this.diferencial, this.x, this.y, this.z);
                        break;
                    case "Escalacion":
                        objeto.Scale((float) this.diferencial, this.x, this.y, this.z);
                        break;
                }
                contador++;
                Thread.Sleep(42);

             
            }
        }
    }
}
