using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramacionGrafica
{
    class Stage
    {
        public Point centro;
        public Dictionary<string, Object> listaDeObjetos;

        public Stage(Point centro, Dictionary<string, Object> listaDeObjetos)
        {
            this.centro = centro;
            this.listaDeObjetos = listaDeObjetos;

            foreach (Object objeto in listaDeObjetos.Values)
            {
                objeto.RefreshCentro(centro);
            }
        }

        public Stage(Point centro)
        {
            this.centro = centro;
            this.listaDeObjetos = new Dictionary<string, Object>();
        }

        public Stage()
        {

        }

        public void Draw()
        {
            foreach (Object objeto in listaDeObjetos.Values)
            {
                objeto.Draw();
            }
        }
        public void Add(string key, Object objeto)
        {
            this.listaDeObjetos.Add(key, objeto);
        }

        public void Remove(string key)
        {
            this.listaDeObjetos.Remove(key);
        }

        public Object Get(string key)
        {
            return this.listaDeObjetos[key];
        }

        public Dictionary<string, Object> GetObjects()
        {
            return listaDeObjetos;
        }

        public void SetCentro(Point centro)
        {
            this.centro = centro;
            foreach (Object objeto in listaDeObjetos.Values)
            {
                objeto.RefreshCentro(this.centro);
            }
        }
        public void Translate(float valorATrasladar, int x, int y, int z)
        {
            foreach (Object objeto in listaDeObjetos.Values)
            {
                objeto.Translate(valorATrasladar, x, y, z);
            }
        }
        public void Scale(float valorAEscalar, int x, int y, int z)
        {
            foreach (Object objeto in listaDeObjetos.Values)
            {
                objeto.Scale(this.centro, valorAEscalar, x, y, z);
            }
        }
        public void Rotate(float valorARotar, int x, int y, int z)
        {
            foreach (Object objeto in listaDeObjetos.Values)
            {
                objeto.Rotate(this.centro, valorARotar, x, y, z);
            }
        }
        public void Limpiar()
        {
            foreach (var objeto in listaDeObjetos)
            {
                objeto.Value.Limpiar();
            }
        }
    }
}
