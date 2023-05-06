﻿
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
        private Stage escenario2;
        Game game;
        public List<Action> actions;
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
            
            escenario = JSON.Load<Stage>("../../JSON/escenario.json");
            escenario2 = JSON.Load<Stage>("../../JSON/escenario3.json");
            escenario.SetCentro(new Point(25, 25, 0));
            escenario2.SetCentro(new Point(-25, -25, 0));
            escenario.Get("auto").SetCentro(new Point(-5, -5, 0));
            escenario.Get("casa").SetCentro(new Point(5, 5, 0));
            escenario2.Get("auto").SetCentro(new Point(5, 5, 0));
            escenario2.Get("lavanda").SetCentro(new Point(-5, -5, 0));
            listaDeEscenarios.Add("Escenario1", escenario);
            listaDeEscenarios.Add("Escenario2", escenario2);
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
            escenario.Limpiar();
            slideX.Value = 0;
            slideY.Value = 0;
            slideZ.Value = 0;

        }
    }
}
