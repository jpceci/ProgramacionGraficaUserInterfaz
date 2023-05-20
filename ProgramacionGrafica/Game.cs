using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace ProgramacionGrafica
{
     class Game : GameWindow
    {
        private Stage escenario;
        private Axis ejeDeCoordenadas = new Axis();
        public Dictionary<string, Stage> listaDeEscenarios;
   
        public Game(int width, int height, string title)
            : base(width, height, GraphicsMode.Default, title)
        {
        
            //escenario = JSON.Load<Stage>("../../JSON/escenario.json");
           
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            GL.ClearColor(Color4.White);
            GL.MatrixMode(MatrixMode.Projection);
            GL.Ortho(-50, 50, -50, 50, -50, 50);
            //GL.Rotate(10f, 1, 0, 0);
            //GL.Rotate(-10f, 0, 1, 0);
           
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
        }
        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);
            base.OnResize(e);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            //ejeDeCoordenadas.Draw();

            //libreto.escenario.Draw();
            foreach (Stage escenario in listaDeEscenarios.Values)
            {
                escenario.Draw();
            }
            //GL.Rotate(2f, 0, 1, 0);
            SwapBuffers();
            base.OnRenderFrame(e);
        }
    }
}
