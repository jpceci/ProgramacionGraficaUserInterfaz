
namespace ProgramacionGrafica
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.escenarioComboBox = new System.Windows.Forms.ComboBox();
            this.objetoComboBox = new System.Windows.Forms.ComboBox();
            this.caraComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.slideX = new System.Windows.Forms.TrackBar();
            this.slideY = new System.Windows.Forms.TrackBar();
            this.slideZ = new System.Windows.Forms.TrackBar();
            this.modoComboBox = new System.Windows.Forms.ComboBox();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.slideX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slideY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slideZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // escenarioComboBox
            // 
            this.escenarioComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.escenarioComboBox.FormattingEnabled = true;
            this.escenarioComboBox.Location = new System.Drawing.Point(48, 198);
            this.escenarioComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.escenarioComboBox.Name = "escenarioComboBox";
            this.escenarioComboBox.Size = new System.Drawing.Size(221, 37);
            this.escenarioComboBox.TabIndex = 0;
            // 
            // objetoComboBox
            // 
            this.objetoComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.objetoComboBox.FormattingEnabled = true;
            this.objetoComboBox.Location = new System.Drawing.Point(48, 245);
            this.objetoComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.objetoComboBox.Name = "objetoComboBox";
            this.objetoComboBox.Size = new System.Drawing.Size(221, 37);
            this.objetoComboBox.TabIndex = 1;
            this.objetoComboBox.SelectedIndexChanged += new System.EventHandler(this.objetoComboBox_SelectedIndexChanged_1);
            // 
            // caraComboBox
            // 
            this.caraComboBox.AccessibleName = "caraComboBox";
            this.caraComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.caraComboBox.FormattingEnabled = true;
            this.caraComboBox.Location = new System.Drawing.Point(48, 297);
            this.caraComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.caraComboBox.Name = "caraComboBox";
            this.caraComboBox.Size = new System.Drawing.Size(221, 37);
            this.caraComboBox.TabIndex = 2;
            this.caraComboBox.Tag = "";
            this.caraComboBox.SelectedIndexChanged += new System.EventHandler(this.caraComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(85, 153);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "Escoger:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(295, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(378, 40);
            this.label2.TabIndex = 4;
            this.label2.Text = "Interfaz de Usuario";
            // 
            // slideX
            // 
            this.slideX.AccessibleName = "XTrackBar";
            this.slideX.Location = new System.Drawing.Point(59, 423);
            this.slideX.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.slideX.Name = "slideX";
            this.slideX.Size = new System.Drawing.Size(693, 56);
            this.slideX.TabIndex = 5;
            this.slideX.Tag = "XTrackBar";
            // 
            // slideY
            // 
            this.slideY.AccessibleName = "YTrackBar";
            this.slideY.Location = new System.Drawing.Point(59, 521);
            this.slideY.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.slideY.Name = "slideY";
            this.slideY.Size = new System.Drawing.Size(693, 56);
            this.slideY.TabIndex = 6;
            this.slideY.Tag = "YTrackBar";
            // 
            // slideZ
            // 
            this.slideZ.AccessibleName = "ZTrackBar";
            this.slideZ.Location = new System.Drawing.Point(59, 612);
            this.slideZ.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.slideZ.Name = "slideZ";
            this.slideZ.Size = new System.Drawing.Size(693, 56);
            this.slideZ.TabIndex = 7;
            this.slideZ.Tag = "ZTrackBar";
            // 
            // modoComboBox
            // 
            this.modoComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modoComboBox.FormattingEnabled = true;
            this.modoComboBox.Location = new System.Drawing.Point(811, 423);
            this.modoComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.modoComboBox.Name = "modoComboBox";
            this.modoComboBox.Size = new System.Drawing.Size(121, 37);
            this.modoComboBox.TabIndex = 8;
            this.modoComboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox4_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(811, 151);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 9;
            this.button1.Text = "Limpiar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(811, 212);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "Animacion";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(1113, 718);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.modoComboBox);
            this.Controls.Add(this.slideZ);
            this.Controls.Add(this.slideY);
            this.Controls.Add(this.slideX);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.caraComboBox);
            this.Controls.Add(this.objetoComboBox);
            this.Controls.Add(this.escenarioComboBox);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.slideX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slideY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slideZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox escenarioComboBox;
        private System.Windows.Forms.ComboBox objetoComboBox;
        private System.Windows.Forms.ComboBox caraComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar slideX;
        private System.Windows.Forms.TrackBar slideY;
        private System.Windows.Forms.TrackBar slideZ;
        private System.Windows.Forms.ComboBox modoComboBox;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

