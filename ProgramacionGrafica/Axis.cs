﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System.Drawing;

namespace ProgramacionGrafica
{
    public class Axis
    {
        public void Draw()
        {
            GL.Begin(PrimitiveType.Lines);

            GL.Color3(Color.Red); //Eje X
            GL.Vertex3(-100, 0, 0);
            GL.Vertex3(100, 0, 0);
            GL.Vertex3(-100, 10, 0);
            GL.Vertex3(100, 10, 0);

            GL.Color3(Color.Blue); //Eje Y
            GL.Vertex3(0, -100, 0);
            GL.Vertex3(0, 100, 0);
            GL.Vertex3(10, -100, 0);
            GL.Vertex3(10, 100, 0);

            GL.Color3(Color.Green); //Eje Z
            GL.Vertex3(0, 0, -500);
            GL.Vertex3(0, 0, 500);

            GL.End();
        }
    }


}
