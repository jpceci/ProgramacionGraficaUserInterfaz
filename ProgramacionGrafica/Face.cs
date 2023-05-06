using System;
using System.Collections.Generic;
using OpenTK.Graphics.OpenGL;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using OpenTK;

namespace ProgramacionGrafica
{
    class Face
    {
        public Point centro { get; set; }
        public List<Point> listaDePuntos { get; set; }
        public Color color { get; set; }
        public Point centroReal { get; set; }
        public Point centroObjeto { get; set; }
        public Transformations matrizTransformacion { get; set; }

        public Face()
        {

        }
        public Face(Point centro, List<Point> listaDePuntos, Color color)
        {
            this.centro = centro;
            this.listaDePuntos = listaDePuntos;
            this.color = color;
            this.centroReal = centro;
            this.centroObjeto = new Point(0, 0, 0);
            this.matrizTransformacion = new Transformations(this.centro);
        }
        public Face(Point centro, Color color)
        {
            this.centro = centro;
            this.listaDePuntos = new List<Point>();
            this.color = color;
        }
        public void Draw()
        {
            GL.Begin(PrimitiveType.LineLoop);
            GL.Color3(color);
            foreach (var point in listaDePuntos)
            {
                Point valores = point * this.matrizTransformacion.GetTransformation();
                GL.Vertex3(valores.x, valores.y, valores.z);
            }
            GL.End();

        }

        public void Add(Point punto)
        {
            this.listaDePuntos.Add(punto);
        }

        public void Remove(int index)
        {
            this.listaDePuntos.RemoveAt(index);
        }

        public Point Get(int index)
        {
            return this.listaDePuntos[index];
        }
       

        public void SetCentro(Point centro)
        {
            this.centroReal = centro;
            this.centro = centroReal + this.centroObjeto;
            this.matrizTransformacion.SetCentro(this.centro.x, this.centro.y, this.centro.z);
        }

        public void RefreshCentro(Point centro)
        {
            this.centroObjeto = centro;
            this.centro = this.centroReal + centroObjeto;
            this.matrizTransformacion.SetCentro(this.centro.x, this.centro.y, this.centro.z);
        }

        public void Translate(float valorATrasladar, int x, int y, int z)
        {

            this.matrizTransformacion.SetTraslacion(valorATrasladar * x, valorATrasladar * y, valorATrasladar * z);
        }

        public void Scale(Point centroAcarreado, float valorAEscalar, int x, int y, int z)
        {
            this.matrizTransformacion.SetCentroAcarreado(centroAcarreado.x, centroAcarreado.y, centroAcarreado.z);
            float escalarX = valorAEscalar * x == 0 ? 1 : valorAEscalar * x;
            float escalarY = valorAEscalar * y == 0 ? 1 : valorAEscalar * y;
            float escalarZ = valorAEscalar * z == 0 ? 1 : valorAEscalar * z;
            this.matrizTransformacion.SetEscalacion(escalarX, escalarY, escalarZ);
        }

        public void Scale(float valorAEscalar, int x, int y, int z)
        {
            this.matrizTransformacion.SetCentroAcarreado(this.centro.x, this.centro.y, this.centro.z);
            float escalarX = valorAEscalar * x == 0 ? 1 : valorAEscalar * x;
            float escalarY = valorAEscalar * y == 0 ? 1 : valorAEscalar * y;
            float escalarZ = valorAEscalar * z == 0 ? 1 : valorAEscalar * z;
            this.matrizTransformacion.SetEscalacion(escalarX, escalarY, escalarZ);
        }
        public void Rotate(Point centroAcarreado, float valorARotar, int x, int y, int z)
        {
            this.matrizTransformacion.SetCentroAcarreado(centroAcarreado.x, centroAcarreado.y, centroAcarreado.z);
            this.matrizTransformacion.SetRotacion(valorARotar * x, valorARotar * y, valorARotar * z);
        }
        public void Rotate(float valorARotar, int x, int y, int z)
        {
            this.matrizTransformacion.SetCentroAcarreado(this.centro.x, this.centro.y, this.centro.z);
            this.matrizTransformacion.SetRotacion(valorARotar * x, valorARotar * y, valorARotar * z);
        }

        public void Limpiar()
        {
            this.matrizTransformacion.Limpiar();

        }
    }
}
