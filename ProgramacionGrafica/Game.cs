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
            List<Point> listaDePuntosCuerpoLateral = new List<Point>();
            listaDePuntosCuerpoLateral.Add(new Point(-2, -6, 0));
            listaDePuntosCuerpoLateral.Add(new Point(10, 4, 0));
            listaDePuntosCuerpoLateral.Add(new Point(8, 6, 0));
            listaDePuntosCuerpoLateral.Add(new Point(5, 4, 0));
            listaDePuntosCuerpoLateral.Add(new Point(-8, 4, 0));
            listaDePuntosCuerpoLateral.Add(new Point(-13, 12, 0));
            listaDePuntosCuerpoLateral.Add(new Point(-17, 14, 0));
            listaDePuntosCuerpoLateral.Add(new Point(-17, 10, 0));
            listaDePuntosCuerpoLateral.Add(new Point(-2, -6, 0));
            listaDePuntosCuerpoLateral.Add(new Point(-2, -12, 0));

            List<Point> listaDePuntosOjo = new List<Point>();
            listaDePuntosOjo.Add(new Point(0, 0.5f, 0));
            listaDePuntosOjo.Add(new Point(0.5f, 0, 0));
            listaDePuntosOjo.Add(new Point(0, -0.5f, 0));
            listaDePuntosOjo.Add(new Point(-0.5f, 0, 0));


            List<Point> listaDePuntosCuerpoSuperior = new List<Point>();
            listaDePuntosCuerpoSuperior.Add(new Point(-17, 6, -1));
            listaDePuntosCuerpoSuperior.Add(new Point(-17, 6, 1));
            listaDePuntosCuerpoSuperior.Add(new Point(-17, 10, 1));
            listaDePuntosCuerpoSuperior.Add(new Point(-13, 8, 1));
            listaDePuntosCuerpoSuperior.Add(new Point(-8, 0, 1));
            listaDePuntosCuerpoSuperior.Add(new Point(5, 0, 1));
            listaDePuntosCuerpoSuperior.Add(new Point(8, 2, 1));
            listaDePuntosCuerpoSuperior.Add(new Point(10, 0, 1));
            listaDePuntosCuerpoSuperior.Add(new Point(10, 0, -1));
            listaDePuntosCuerpoSuperior.Add(new Point(8, 2, -1));
            listaDePuntosCuerpoSuperior.Add(new Point(5, 0, -1));
            listaDePuntosCuerpoSuperior.Add(new Point(-8, 0, -1));
            listaDePuntosCuerpoSuperior.Add(new Point(-13, 8, -1));
            listaDePuntosCuerpoSuperior.Add(new Point(-17, 10, -1));

            List<Point> listaDePuntosCuerpoInferior = new List<Point>();
            listaDePuntosCuerpoInferior.Add(new Point(-17, 14, -1));
            listaDePuntosCuerpoInferior.Add(new Point(-17, 14, 1));
            listaDePuntosCuerpoInferior.Add(new Point(-2, -2, 1));
            listaDePuntosCuerpoInferior.Add(new Point(10, 8, 1));
            listaDePuntosCuerpoInferior.Add(new Point(10, 8, -1));
            listaDePuntosCuerpoInferior.Add(new Point(-2, -2, -1));

            List<Point> listaDePuntosAlasLaterales = new List<Point>();
            listaDePuntosAlasLaterales.Add(new Point(5, 0, 0));
            listaDePuntosAlasLaterales.Add(new Point(-8, -4, 0));
            listaDePuntosAlasLaterales.Add(new Point(-1, 5, 0));
       

            Face cuerpoDerecho = new Face(new Point(0, 0, 1), listaDePuntosCuerpoLateral, Color.Red);
            Face cuerpoIzquierdo = new Face(new Point(0, 0, -1), listaDePuntosCuerpoLateral, Color.Red);
            Face cuerpoSuperior = new Face(new Point(0, 4, 0), listaDePuntosCuerpoSuperior, Color.Red);
            Face cuerpoInferior = new Face(new Point(0, -4, 0), listaDePuntosCuerpoInferior, Color.Red);
            Face ojitoDerecho = new Face(new Point(8, 4, 1), listaDePuntosOjo, Color.Black);
            Face ojitoIzquierdo = new Face(new Point(8, 4, -1), listaDePuntosOjo, Color.Black);
            Face alaDerecha = new Face(new Point(0, 0, 1), listaDePuntosAlasLaterales, Color.Red);
            Face alaIzquierda = new Face(new Point(0, 0, -1), listaDePuntosAlasLaterales, Color.Red);

            Dictionary<string, Face> listaDeCarasPajaro = new Dictionary<string, Face>();
            listaDeCarasPajaro.Add("cuerpoDerecho", cuerpoDerecho);
            listaDeCarasPajaro.Add("cuerpoIzquierdo", cuerpoIzquierdo);
            listaDeCarasPajaro.Add("cuerpoSuperior", cuerpoSuperior);
            listaDeCarasPajaro.Add("cuerpoInferior", cuerpoInferior);
            listaDeCarasPajaro.Add("ojitoDerecho", ojitoDerecho);
            listaDeCarasPajaro.Add("ojitoIzquierdo", ojitoIzquierdo);
            listaDeCarasPajaro.Add("alaDerecha", alaDerecha);
            listaDeCarasPajaro.Add("alaIzquierda", alaIzquierda);


            List<Point> listaDePuntosFT = new List<Point>();
            listaDePuntosFT.Add(new Point(-4, 4, 0)); //"puntoIzquierdoArriba"
            listaDePuntosFT.Add(new Point(-4, -4, 0)); //"puntoIzquierdoAbajo"
            listaDePuntosFT.Add(new Point(4, -4, 0)); // "puntoDerechoAbajo", 
            listaDePuntosFT.Add(new Point(4, 4, 0)); //"puntoDerechoArriba"

            List<Point> listaDePuntosLaterales = new List<Point>();
            listaDePuntosLaterales.Add(new Point(0, 4, 4)); //"puntoIzquierdoArriba", 
            listaDePuntosLaterales.Add(new Point(0, -4, 4)); //"puntoIzquierdoAbajo", 
            listaDePuntosLaterales.Add(new Point(0, -4, -4)); //"puntoDerechoAbajo",
            listaDePuntosLaterales.Add(new Point(0, 4, -4)); //"puntoDerechoArriba",

            List<Point> listaDePuntosTechoFT = new List<Point>();
            listaDePuntosTechoFT.Add(new Point(-4, -2, 0)); //"puntoIzquierdoAbajo", 
            listaDePuntosTechoFT.Add(new Point(4, -2, 0)); //"puntoDerechoAbajo", 
            listaDePuntosTechoFT.Add(new Point(0, 2, 0)); //"puntoArriba", 

            List<Point> listaDePuntosTechoDerecho = new List<Point>();
            listaDePuntosTechoDerecho.Add(new Point(-2, 2, 4)); //"puntoIzquierdoArriba",
            listaDePuntosTechoDerecho.Add(new Point(2, -2, 4)); //"puntoIzquierdoAbajo",
            listaDePuntosTechoDerecho.Add(new Point(2, -2, -4)); //"puntoDerechoAbajo",
            listaDePuntosTechoDerecho.Add(new Point(-2, 2, -4)); //"puntoDerechoArriba",

            List<Point> listaDePuntosTechoIzquierdo = new List<Point>();
            listaDePuntosTechoIzquierdo.Add(new Point(2, 2, 4)); //"puntoIzquierdoArriba",
            listaDePuntosTechoIzquierdo.Add(new Point(-2, -2, 4)); //"puntoIzquierdoAbajo",
            listaDePuntosTechoIzquierdo.Add(new Point(-2, -2, -4)); //"puntoDerechoAbajo",
            listaDePuntosTechoIzquierdo.Add(new Point(2, 2, -4)); //"puntoDerechoArriba",

            Face caraFrente = new Face(new Point(0, 0, 4), listaDePuntosFT, Color.FromArgb(230, 182, 110));
            Face caraAtras = new Face(new Point(0, 0, -4), listaDePuntosFT, Color.FromArgb(230, 182, 110));
            Face caraDerecha = new Face(new Point(4, 0, 0), listaDePuntosLaterales, Color.FromArgb(230, 182, 110));
            Face caraIzquierda = new Face(new Point(-4, 0, 0), listaDePuntosLaterales, Color.FromArgb(230, 182, 110));
            Face caraTechoFrente = new Face(new Point(0, 6, 4), listaDePuntosTechoFT, Color.FromArgb(161, 24, 24));
            Face caraTechoTrasera = new Face(new Point(0, 6, -4), listaDePuntosTechoFT, Color.FromArgb(161, 24, 24));
            Face caraTechoDerecho = new Face(new Point(2, 6, 0), listaDePuntosTechoDerecho, Color.FromArgb(161, 24, 24));
            Face caraTechoIzquierdo = new Face(new Point(-2, 6, 0), listaDePuntosTechoIzquierdo, Color.FromArgb(161, 24, 24));

            List<Point> listaDePuntosFTAuto = new List<Point>();
            listaDePuntosFTAuto.Add(new Point(-2, 2, 0)); //"puntoIzquierdoArriba",
            listaDePuntosFTAuto.Add(new Point(-2, -2, 0)); //"puntoIzquierdoAbajo",
            listaDePuntosFTAuto.Add(new Point(2, -2, 0)); //"puntoDerechoAbajo",
            listaDePuntosFTAuto.Add(new Point(2, 2, 0)); //"puntoDerechoArriba",

            List<Point> listaDePuntosLateralesAuto = new List<Point>();
            listaDePuntosLateralesAuto.Add(new Point(0, 2, 5)); //"puntoIzquierdoArriba", 
            listaDePuntosLateralesAuto.Add(new Point(0, -2, 5)); //"puntoIzquierdoAbajo"
            listaDePuntosLateralesAuto.Add(new Point(0, -2, -5)); //"puntoDerechoAbajo", 
            listaDePuntosLateralesAuto.Add(new Point(0, 2, -5)); //"puntoDerechoArriba", 

            List<Point> listaDePuntosFTTechoAuto = new List<Point>();
            listaDePuntosFTTechoAuto.Add(new Point(-1, 1, 0)); //"puntoIzquierdoArriba", 
            listaDePuntosFTTechoAuto.Add(new Point(-1, -1, 0)); //"puntoIzquierdoAbajo", 
            listaDePuntosFTTechoAuto.Add(new Point(1, -1, 0)); //"puntoDerechoAbajo",
            listaDePuntosFTTechoAuto.Add(new Point(1, 1, 0)); //"puntoDerechoArriba",

            List<Point> listaDePuntosLateralesTechoAuto = new List<Point>();
            listaDePuntosLateralesTechoAuto.Add(new Point(0, 1, 3)); //"puntoIzquierdoArriba", 
            listaDePuntosLateralesTechoAuto.Add(new Point(0, -1, 3)); //"puntoIzquierdoAbajo"
            listaDePuntosLateralesTechoAuto.Add(new Point(0, -1, -3)); //"puntoDerechoAbajo", 
            listaDePuntosLateralesTechoAuto.Add(new Point(0, 1, -3)); //"puntoDerechoArriba", 

            List<Point> listaDePuntosRueda = new List<Point>();
            for (int i = 0; i < 180; i += 2)
            {
                listaDePuntosRueda.Add(new Point(0, (float)Math.Cos(i) * 1.5f, (float)Math.Sin(i) * 1.5f));
            }

            Face caraFrenteAuto = new Face(new Point(0, 0, 5), listaDePuntosFTAuto, Color.FromArgb(65, 142, 255));
            Face caraAtrasAuto = new Face(new Point(0, 0, -5), listaDePuntosFTAuto, Color.FromArgb(65, 142, 255));
            Face caraDerechaAuto = new Face(new Point(2, 0, 0), listaDePuntosLateralesAuto, Color.FromArgb(65, 142, 255));
            Face caraIzquierdaAuto = new Face(new Point(-2, 0, 0), listaDePuntosLateralesAuto, Color.FromArgb(65, 142, 255));
            Face caraTechoFrenteAuto = new Face(new Point(0, 3, 3), listaDePuntosFTTechoAuto, Color.FromArgb(143, 221, 243));
            Face caraTechoAtrasAuto = new Face(new Point(0, 3, -3), listaDePuntosFTTechoAuto, Color.FromArgb(143, 221, 243));
            Face caraTechoDerechaAuto = new Face(new Point(1, 3, 0), listaDePuntosLateralesTechoAuto, Color.FromArgb(143, 221, 243));
            Face caraTechoIzquierdaAuto = new Face(new Point(-1, 3, 0), listaDePuntosLateralesTechoAuto, Color.FromArgb(143, 221, 243));
            Face ruedaDerechaDelantera = new Face(new Point(2, -2, 2), listaDePuntosRueda, Color.Black);
            Face ruedaDerechaTrasera = new Face(new Point(2, -2, -2), listaDePuntosRueda, Color.Black);
            Face ruedaIzquierdaDelantera = new Face(new Point(-2, -2, 2), listaDePuntosRueda, Color.Black);
            Face ruedaIzquierdaTrasera = new Face(new Point(-2, -2, -2), listaDePuntosRueda, Color.Black);

            Dictionary<string, Face> listaDeCarasAuto = new Dictionary<string, Face>();
            listaDeCarasAuto.Add("caraFrenteAuto", caraFrenteAuto);
            listaDeCarasAuto.Add("caraAtras", caraAtrasAuto);
            listaDeCarasAuto.Add("caraDerechaAuto", caraDerechaAuto);
            listaDeCarasAuto.Add("caraIzquierdaAuto", caraIzquierdaAuto);
            listaDeCarasAuto.Add("caraTechoFrenteAuto", caraTechoFrenteAuto);
            listaDeCarasAuto.Add("caraTechoAtrasAuto", caraTechoAtrasAuto);
            listaDeCarasAuto.Add("caraTechoDerechaAuto", caraTechoDerechaAuto);
            listaDeCarasAuto.Add("caraTechoIzquierdaAuto", caraTechoIzquierdaAuto);
            listaDeCarasAuto.Add("ruedaDerechaDelantera", ruedaDerechaDelantera);
            listaDeCarasAuto.Add("ruedaDerechaTrasera", ruedaDerechaTrasera);
            listaDeCarasAuto.Add("ruedaIzquierdaDelantera", ruedaIzquierdaDelantera);
            listaDeCarasAuto.Add("ruedaIzquierdaTrasera", ruedaIzquierdaTrasera);

            Dictionary<string, Face> listaDeCaras = new Dictionary<string, Face>();
            listaDeCaras.Add("caraFrente", caraFrente);
            listaDeCaras.Add("caraAtras", caraAtras);
            listaDeCaras.Add("caraDerecha", caraDerecha);
            listaDeCaras.Add("caraIzquierda", caraIzquierda);
            listaDeCaras.Add("caraTechoFrente", caraTechoFrente);
            listaDeCaras.Add("caraTechoTrasera", caraTechoTrasera);
            listaDeCaras.Add("caraTechoDerecho", caraTechoDerecho);
            listaDeCaras.Add("caraTechoIzquierdo", caraTechoIzquierdo);

            Object casa = new Object(new Point(0, 0, 0), listaDeCaras);
            Object auto = new Object(new Point(-40, 0, 20), listaDeCarasAuto);
            Object pajaro = new Object(new Point(2, 20, 0), listaDeCarasPajaro);

            Dictionary<string, Object> listaDeObjetos = new Dictionary<string, Object>();
            listaDeObjetos.Add("auto", auto);
            listaDeObjetos.Add("casa", casa);
            listaDeObjetos.Add("pajaro", pajaro);

            //escenario = new Stage(new Point(0, 0, 0), listaDeObjetos);
            //JSON.Save("../../JSON/escenarioPajarito.json", escenario);
            escenario = JSON.Load<Stage>("../../JSON/escenarioPajarito.json");

        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            GL.ClearColor(Color4.White);
            GL.MatrixMode(MatrixMode.Projection);
            GL.Ortho(-70, 70, -70, 70, -70, 70);

            GL.Rotate(15f, 0, 1, 0);
            GL.Rotate(20f, 1, 0, 0);
            
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

            //escenario.Draw();
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
