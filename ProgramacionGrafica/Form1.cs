
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace ProgramacionGrafica
{
    public partial class Form1 : Form
    {

        private Stage escenario;
        private Execution ejecutador;

        Game game;
        private List<Convert> listaDeConversiones = new List<Convert>();
        private List<Convert> listaDeConversionesPajaro = new List<Convert>();
        private Script libreto;
        Dictionary<string, Stage> listaDeEscenarios = new Dictionary<string, Stage>();

        private float minRotate = -90f;
        private float maxRotate = 90f;
        private float minTraslate = -30f;
        private float maxTraslate = 30f;
        private float minScale = 0f;
        private float maxScale = 2f;

        public Form1()
        {
            InitializeComponent();
            this.escenarioComboBox.SelectedIndexChanged += new System.EventHandler(this.escenarioComboBox_SelectedIndexChanged);
            objetoComboBox.SelectedIndexChanged += new System.EventHandler(this.objetoComboBox_SelectedIndexChanged);
            slideX.ValueChanged += new System.EventHandler(this.SliderHandler);
            slideY.ValueChanged += new System.EventHandler(this.SliderHandler);
            slideZ.ValueChanged += new System.EventHandler(this.SliderHandler);
            modoComboBox.SelectedIndexChanged += new System.EventHandler(this.ModeSelected);
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            
            escenario = new Stage(new Point(0, 0, 0));

            Thread hilo = new Thread(gameStart);
            hilo.Start();
            
            escenario = JSON.Load<Stage>("../../JSON/escenarioPajarito.json");
            escenario.Get("pajaro").Rotate(185, 0, 1, 0);
            escenario.Get("pajaro").Scale(0.5f, 1, 1, 1);
            escenario.Get("casa").Scale(2, 1, 1, 1);
            escenario.Get("auto").Scale(1.5f, 1, 1, 1);


            Convert accion = new Convert("Traslacion", -30, 0, 0, 1, 3000, 0);
            Convert accion1 = new Convert("Traslacion", -7, -1, 0, 1, 1000, 3000);
            Convert accion11 = new Convert("Traslacion", -7, -1, 0, 1, 1000, 4000);
            Convert accion2 = new Convert("Rotacion", -90, 0, 1, 0, 2000, 3000);
            Convert accion3 = new Convert("Traslacion", 10, 1, 0, 0, 1000, 5000);
            Convert accion31 = new Convert("Traslacion", 40, 1, 0, 0, 3000, 6000);
            Convert accion32 = new Convert("Traslacion", 10, 1, 0, 0, 1000, 9000);
            Convert accion33 = new Convert("Traslacion", 7, 1, 0, 1, 1000, 10000);
            Convert accion34 = new Convert("Traslacion", 7, 1, 0, 1, 1000, 11000);
            Convert accion4 = new Convert("Rotacion", -90, 0, 1, 0, 2000, 10000);
            Convert accion5 = new Convert("Traslacion", 30, 0, 0, 1, 2000, 12000);
            Convert accion51 = new Convert("Traslacion", -7, 1, 0, -1, 1000, 14000);
            Convert accion52 = new Convert("Traslacion", -7, 1, 0, -1, 1000, 15000);
            Convert accion6 = new Convert("Rotacion", -90, 0, 1, 0, 2000, 14000);
            Convert accion7= new Convert("Traslacion", -10, 1, 0, 0, 1000, 16000);
            Convert accion71 = new Convert("Traslacion", -40, 1, 0, 0, 3000, 17000);
            Convert accion72 = new Convert("Traslacion", -10, 1, 0, 0, 1000, 20000);
            Convert accion73 = new Convert("Traslacion", -7, 1, 0, 1, 1000, 21000);
            Convert accion74 = new Convert("Traslacion", -7, 1, 0, 1, 1000, 22000);
            Convert accion8 = new Convert("Rotacion", -90, 0, 1, 0, 2000, 21000);

            listaDeConversiones.Add(accion);
            listaDeConversiones.Add(accion1);
            listaDeConversiones.Add(accion11);
            listaDeConversiones.Add(accion2);
            listaDeConversiones.Add(accion3);
            listaDeConversiones.Add(accion31);
            listaDeConversiones.Add(accion32);
            listaDeConversiones.Add(accion33);
            listaDeConversiones.Add(accion34);
            listaDeConversiones.Add(accion4);
            listaDeConversiones.Add(accion5);
            listaDeConversiones.Add(accion51);
            listaDeConversiones.Add(accion52);
            listaDeConversiones.Add(accion6);
            listaDeConversiones.Add(accion7);
            listaDeConversiones.Add(accion71);
            listaDeConversiones.Add(accion72);
            listaDeConversiones.Add(accion73);
            listaDeConversiones.Add(accion74);
            listaDeConversiones.Add(accion8);

            Convert rotar = new Convert("Rotacion", -90, 0, 1, 0, 6500, 0);
            Convert rotar1 = new Convert("Rotacion", -90, 0, 1, 0, 7000, 6500);
            Convert rotar2 = new Convert("Rotacion", -90, 0, 1, 0, 6500, 13500);
            Convert rotar3 = new Convert("Rotacion", -70, 0, 1, 0, 4500, 20000);
            listaDeConversionesPajaro.Add(rotar);
            listaDeConversionesPajaro.Add(rotar1);
            listaDeConversionesPajaro.Add(rotar2);
            listaDeConversionesPajaro.Add(rotar3);
            

            Action acciones = new Action("auto", listaDeConversiones);
            Action moverPajaro = new Action("pajaro", listaDeConversionesPajaro);
            List<Action> listaDeAcciones = new List<Action>();
            listaDeAcciones.Add(acciones);
            listaDeAcciones.Add(moverPajaro);

            libreto = new Script(listaDeAcciones, escenario);
            ejecutador = new Execution(libreto);
  
            listaDeEscenarios.Add("Escenario1", escenario);


            setSlidersRange(0, 50);

            foreach (var key in listaDeEscenarios.Keys)
            {
                escenarioComboBox.Items.Add(key);
            }
            escenarioComboBox.SelectedIndex = 0;

            loadObjetosComboBox();
            LoadCarasComboBox();
            modoComboBox.Items.Add("Rotación");
            modoComboBox.Items.Add("Traslación");
            modoComboBox.Items.Add("Escalado");
            modoComboBox.SelectedIndex = 0;

        }

        private void loadObjetosComboBox()
        {
            objetoComboBox.Items.Clear();
            Stage escenarioSeleccionado = listaDeEscenarios[escenarioComboBox.SelectedItem?.ToString()];

            objetoComboBox.Items.Add("Escenario");
            foreach (var obj in escenarioSeleccionado.listaDeObjetos)
            {
                objetoComboBox.Items.Add(obj.Key);
            }
            objetoComboBox.SelectedIndex = 0;
        }
        private void escenarioComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadObjetosComboBox();
            LoadCarasComboBox();
        }

        private void LoadCarasComboBox()
        {
            caraComboBox.Items.Clear();
            var selectedEscenario = listaDeEscenarios[escenarioComboBox.SelectedItem?.ToString()];

            if (objetoComboBox.SelectedItem.ToString() == "Escenario")
            {
                caraComboBox.Enabled = false;
                return;
            }

            caraComboBox.Enabled = true;
            var objetoSeleccionado = selectedEscenario.listaDeObjetos[objetoComboBox.SelectedItem?.ToString()];

            caraComboBox.Items.Add("Objeto");
            foreach (var obj in objetoSeleccionado.listaDeCaras)
            {
                caraComboBox.Items.Add(obj.Key);
            }

            caraComboBox.SelectedIndex = 0;
        }

        private void objetoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCarasComboBox();
        }

        private void gameStart()
        {
            game = new Game(500, 500, "BTS");
            game.listaDeEscenarios = this.listaDeEscenarios;
            game.Run();
            
        }

        private void setSlidersRange(float minValue, float maxValue)
        {
            slideX.Minimum = (int)minValue;
            slideX.Maximum = (int)maxValue;
            slideY.Minimum = (int)minValue;
            slideY.Maximum = (int)maxValue;
            slideZ.Minimum = (int)minValue;
            slideZ.Maximum = (int)maxValue;

            if (modoComboBox.SelectedItem == "Escalado")
            {
                slideX.Value = 1;
                slideY.Value = 1;
                slideZ.Value = 1;
                return;
            }

            slideX.Value = 0;
            slideY.Value = 0;
            slideZ.Value = 0;
        }
        private void ModeSelected(object sender, EventArgs e)
        {
            switch (modoComboBox.SelectedItem)
            {
                case "Rotación":
                    setSlidersRange(this.minRotate, this.maxRotate);
                    break;
                case "Traslación":
                    setSlidersRange(this.minTraslate, this.maxTraslate);
                    break;
                case "Escalado":
                    setSlidersRange(this.minScale, this.maxScale);
                    break;
            }
        }
            private void SliderHandler(object sender, EventArgs e)
            {
            if (slideX != null && slideY != null && slideZ != null)
            {
                string modo = (string)modoComboBox.SelectedItem;
                string objetoString = (string)objetoComboBox.SelectedItem;
                string caraString = (string)caraComboBox.SelectedItem;

                if (modo == "Rotación")
                {
                    if (objetoString == "Escenario")
                    {   
                        game.listaDeEscenarios[escenarioComboBox.SelectedItem?.ToString()].Rotate((float)slideX.Value, 1, 0, 0);
                        game.listaDeEscenarios[escenarioComboBox.SelectedItem?.ToString()].Rotate((float)slideY.Value, 0, 1, 0);
                        game.listaDeEscenarios[escenarioComboBox.SelectedItem?.ToString()].Rotate((float)slideZ.Value, 0, 0, 1);
                    }

                    else
                    {
                        
                        Object objetoAProcesar = game.listaDeEscenarios[escenarioComboBox.SelectedItem?.ToString()].Get(objetoString);

                        if (caraString == "Objeto")
                        {
                            objetoAProcesar.Rotate((float)slideX.Value, 1, 0, 0);
                            objetoAProcesar.Rotate((float)slideY.Value, 0, 1, 0);
                            objetoAProcesar.Rotate((float)slideZ.Value, 0, 0, 1);

                            return;
                        }

                        Face caraAProcesar = objetoAProcesar.Get(caraString);
                        caraAProcesar.Rotate((float)slideX.Value, 1, 0, 0);
                        caraAProcesar.Rotate((float)slideY.Value, 0, 1, 0);
                        caraAProcesar.Rotate((float)slideZ.Value, 0, 0, 1);
                    }

                    return;
                }

                if (modo == "Traslación")
                {
                    if (objetoString == "Escenario")
                    {
                        game.listaDeEscenarios[escenarioComboBox.SelectedItem?.ToString()].Translate((float)slideX.Value, 1, 0, 0);
                        game.listaDeEscenarios[escenarioComboBox.SelectedItem?.ToString()].Translate((float)slideY.Value, 0, 1, 0);
                        game.listaDeEscenarios[escenarioComboBox.SelectedItem?.ToString()].Translate((float)slideZ.Value, 0, 0, 1);
                    }
                    else
                    {
                        Object objetoAProcesar = game.listaDeEscenarios[escenarioComboBox.SelectedItem?.ToString()].Get(objetoString);
                   
                        if (caraString == "Objeto")
                        {
                            objetoAProcesar.Translate((float)slideX.Value, 1, 0, 0);
                            objetoAProcesar.Translate((float)slideY.Value, 0, 1, 0);
                            objetoAProcesar.Translate((float)slideZ.Value, 0, 0, 1);
                            return;
                        }

                        Face caraAProcesar = objetoAProcesar.Get(caraString);
                        caraAProcesar.Translate((float)slideX.Value, 1, 0, 0);
                        caraAProcesar.Translate((float)slideY.Value, 0, 1, 0);
                        caraAProcesar.Translate((float)slideZ.Value, 0, 0, 1);

                    }

                    return;
                }

                if (modo == "Escalado")
                {
                    if (objetoString == "Escenario")
                    {
                        game.listaDeEscenarios[escenarioComboBox.SelectedItem?.ToString()].Scale((float)slideX.Value, 1, 0, 0);
                        game.listaDeEscenarios[escenarioComboBox.SelectedItem?.ToString()].Scale((float)slideY.Value, 0, 1, 0);
                        game.listaDeEscenarios[escenarioComboBox.SelectedItem?.ToString()].Scale((float)slideZ.Value, 0, 0, 1);
                    }
                    else
                    {
                        Object objetoAProcesar = game.listaDeEscenarios[escenarioComboBox.SelectedItem?.ToString()].Get(objetoString); 
                        if (caraString == "Objeto")
                        {
                            objetoAProcesar.Scale((float)slideX.Value, 1, 0, 0);
                            objetoAProcesar.Scale((float)slideY.Value, 0, 1, 0);
                            objetoAProcesar.Scale((float)slideZ.Value, 0, 0, 1);
                            return;
                        }

                        Face caraAProcesar = objetoAProcesar.Get(caraString);
                        caraAProcesar.Scale((float)slideX.Value, 1, 0, 0);
                        caraAProcesar.Scale((float)slideY.Value, 0, 1, 0);
                        caraAProcesar.Scale((float)slideZ.Value, 0, 0, 1);

                    }
                }
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void caraComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void objetoComboBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Limpiar();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Limpiar();
            ejecutador.Execute();
        }

        private void Limpiar()
        {
            escenario.Limpiar();
            escenario.Get("pajaro").Rotate(185, 0, 1, 0);
            escenario.Get("pajaro").Scale(0.5f, 1, 1, 1);
            escenario.Get("casa").Scale(2, 1, 1, 1);
            escenario.Get("auto").Scale(1.5f, 1, 1, 1);

            slideX.Value = 0;
            slideY.Value = 0;
            slideZ.Value = 0;
        }
    }
}
