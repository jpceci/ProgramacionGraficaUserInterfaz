using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace ProgramacionGrafica
{
    class Transformations
    {

        public Matrix4 rotacion { get; set; }
        public Matrix4 traslacion { get; set; }
        public Matrix4 escalacion { get; set; }
        public Matrix4 transformacion { get; set; }
        public Matrix4 centroAcarreado { get; set; }
        public Matrix4 centro { get; set; }

        public Transformations(Point centro)
        {
            this.rotacion = Matrix4.Identity;
            this.traslacion = Matrix4.Identity;
            this.escalacion = Matrix4.Identity;
            this.transformacion = Matrix4.Identity;
            this.centro = Matrix4.CreateTranslation(centro.x, centro.y, centro.z);
            this.centroAcarreado = Matrix4.Identity;

        }

        public void SetTransformation()
        {
            this.transformacion = this.centro * this.centroAcarreado.Inverted() * this.rotacion * this.escalacion * this.traslacion * this.centroAcarreado;
        }
        public Matrix4 GetTransformation()
        {
            SetTransformation();
            return this.transformacion;
        }
        public void SetCentroAcarreado(float x, float y, float z)
        {
            this.centroAcarreado = Matrix4.CreateTranslation(x, y, z);
        }
        public void SetCentro(float x, float y, float z)
        {
            this.centro = Matrix4.CreateTranslation(x, y, z);
        }
        public void SetTraslacion(float x, float y, float z)
        {
            this.traslacion *= Matrix4.CreateTranslation(x, y, z);

        }
        public void SetEscalacion(float x, float y, float z)
        {
            this.escalacion *= Matrix4.CreateScale(x, y, z);

        }

        public void SetRotacion(float x, float y, float z)
        {
            float rotarX = MathHelper.DegreesToRadians(x);
            float rotarY = MathHelper.DegreesToRadians(y);
            float rotarZ = MathHelper.DegreesToRadians(z);
            this.rotacion *= Matrix4.CreateRotationX(rotarX) * Matrix4.CreateRotationY(rotarY) * Matrix4.CreateRotationZ(rotarZ);

        }

        public void Limpiar()
        {
            this.rotacion = Matrix4.Identity;
            this.traslacion = Matrix4.Identity;
            this.escalacion = Matrix4.Identity;
            this.centroAcarreado = Matrix4.Identity;
        }
    }
}
