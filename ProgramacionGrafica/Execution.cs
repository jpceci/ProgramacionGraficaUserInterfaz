using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ProgramacionGrafica
{
    class Execution
    {
        Script libreto;
       
        public Execution(Script libreto)
        {
            this.libreto = libreto;
        }

        public void Execute()
        {
            int tiempoInicial = Environment.TickCount;
            int tiempoTotal = 28000;
            List<Action> listaDeAcciones = libreto.listaDeAcciones;

            while (true)
            {
                int tiempoTranscurrido = Environment.TickCount - tiempoInicial;

                if (tiempoTranscurrido >= tiempoTotal)
                {
                    break;
                }

                foreach (Action accion in listaDeAcciones)
                {
                    int tiempoActual = Environment.TickCount - tiempoInicial;
                    Object objeto = libreto.escenario.Get(accion.keyObjeto);
                    List<Convert> listaDeConversiones = accion.listaDeConversiones;
                    foreach (Convert conversion in listaDeConversiones)
                    {
                        if (tiempoActual >= conversion.tiempoInicio && tiempoActual <= (conversion.tiempoInicio + conversion.duracion))
                        {
                            if (conversion.LastExecutionTime == 0 || (Environment.TickCount - conversion.LastExecutionTime) >= 42)
                            {
                                //Console.WriteLine(Environment.TickCount - conversion.LastExecutionTime);
                                RunConversion(objeto,conversion);
                                conversion.LastExecutionTime = Environment.TickCount;
                            }
                        }
                    }
                    
                }
                Thread.Sleep(1); // Pequeña pausa para evitar uso intensivo de CPU
            }
        }


        private void RunConversion(Object objeto, Convert conversion)
        {
            float diferencial = (float) conversion.diferencial;
            switch (conversion.transformacion)
                {
                    case "Traslacion":
                        objeto.Translate(diferencial, conversion.x, conversion.y, conversion.z);
                        break;
                    case "Rotacion":
                        objeto.Rotate(diferencial, conversion.x, conversion.y, conversion.z);
                        break;
                    case "Escalacion":
                        objeto.Scale(diferencial, conversion.x, conversion.y, conversion.z);
                        break;
                }
        }
    }
}
