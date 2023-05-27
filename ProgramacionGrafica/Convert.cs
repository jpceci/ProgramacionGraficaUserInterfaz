using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramacionGrafica
{
    class Convert
    {
        
        public string transformacion;
        public int cantidadATransformar;
        public int x, y, z;
        public long duracion;
        public long tiempoInicio;
        public decimal diferencial;
        public long segundos = 0;
        public long LastExecutionTime = 0;

        public Convert(string transformacion, int cantidadATransformar, int x, int y, int z, long duracion, long tiempoInicio)
        {
            this.transformacion = transformacion;
            this.cantidadATransformar = cantidadATransformar;
            this.x = x;
            this.y = y;
            this.z = z;
            this.duracion = duracion;
            this.tiempoInicio = tiempoInicio;
            segundos = this.duracion / 1000;
            diferencial = (decimal)this.cantidadATransformar / (22 * segundos);
        }
    }
}
