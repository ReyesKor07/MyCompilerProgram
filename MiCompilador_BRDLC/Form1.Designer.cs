using System;
using System.Runtime.InteropServices;

namespace micompilador_ACC
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lenguajeOriginalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lenguajeTraducidoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salidaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serviciosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ejemplosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ejemplosToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ejemplo1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ejemplo2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ejemplo3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.TextoTraducido = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.TxtNoTraducido = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnCompilar = new System.Windows.Forms.Button();
            this.lstlenguajetraducido = new System.Windows.Forms.ListBox();
            this.lstlenguajeoriginal = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lst_Errores = new System.Windows.Forms.ListView();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.serviciosToolStripMenuItem,
            this.acercaDeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(995, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lenguajeOriginalToolStripMenuItem,
            this.lenguajeTraducidoToolStripMenuItem,
            this.salidaToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // lenguajeOriginalToolStripMenuItem
            // 
            this.lenguajeOriginalToolStripMenuItem.Name = "lenguajeOriginalToolStripMenuItem";
            this.lenguajeOriginalToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.lenguajeOriginalToolStripMenuItem.Text = "Lenguaje original";
            this.lenguajeOriginalToolStripMenuItem.Click += new System.EventHandler(this.lenguajeOriginalToolStripMenuItem_Click);
            // 
            // lenguajeTraducidoToolStripMenuItem
            // 
            this.lenguajeTraducidoToolStripMenuItem.Name = "lenguajeTraducidoToolStripMenuItem";
            this.lenguajeTraducidoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.lenguajeTraducidoToolStripMenuItem.Text = "Lenguaje traducido";
            this.lenguajeTraducidoToolStripMenuItem.Click += new System.EventHandler(this.lenguajeTraducidoToolStripMenuItem_Click);
            // 
            // salidaToolStripMenuItem
            // 
            this.salidaToolStripMenuItem.Name = "salidaToolStripMenuItem";
            this.salidaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.salidaToolStripMenuItem.Text = "salida";
            this.salidaToolStripMenuItem.Click += new System.EventHandler(this.salidaToolStripMenuItem_Click);
            // 
            // serviciosToolStripMenuItem
            // 
            this.serviciosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ayudaToolStripMenuItem,
            this.ejemplosToolStripMenuItem,
            this.ejemplosToolStripMenuItem1});
            this.serviciosToolStripMenuItem.Name = "serviciosToolStripMenuItem";
            this.serviciosToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.serviciosToolStripMenuItem.Text = "Servicios";
            // 
            // ayudaToolStripMenuItem
            // 
            this.ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            this.ayudaToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.ayudaToolStripMenuItem.Text = "ayuda";
            this.ayudaToolStripMenuItem.Click += new System.EventHandler(this.ayudaToolStripMenuItem_Click);
            // 
            // ejemplosToolStripMenuItem
            // 
            this.ejemplosToolStripMenuItem.Name = "ejemplosToolStripMenuItem";
            this.ejemplosToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.ejemplosToolStripMenuItem.Text = "Ejemplos";
            this.ejemplosToolStripMenuItem.Click += new System.EventHandler(this.ejemplosToolStripMenuItem_Click);
            // 
            // ejemplosToolStripMenuItem1
            // 
            this.ejemplosToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ejemplo1ToolStripMenuItem,
            this.ejemplo2ToolStripMenuItem,
            this.ejemplo3ToolStripMenuItem});
            this.ejemplosToolStripMenuItem1.Name = "ejemplosToolStripMenuItem1";
            this.ejemplosToolStripMenuItem1.Size = new System.Drawing.Size(125, 22);
            this.ejemplosToolStripMenuItem1.Text = "Ejemplos_";
            // 
            // ejemplo1ToolStripMenuItem
            // 
            this.ejemplo1ToolStripMenuItem.Name = "ejemplo1ToolStripMenuItem";
            this.ejemplo1ToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.ejemplo1ToolStripMenuItem.Text = "Ejemplo 1";
            this.ejemplo1ToolStripMenuItem.Click += new System.EventHandler(this.ejemplo1ToolStripMenuItem_Click);
            // 
            // ejemplo2ToolStripMenuItem
            // 
            this.ejemplo2ToolStripMenuItem.Name = "ejemplo2ToolStripMenuItem";
            this.ejemplo2ToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.ejemplo2ToolStripMenuItem.Text = "Ejemplo 2";
            this.ejemplo2ToolStripMenuItem.Click += new System.EventHandler(this.ejemplo2ToolStripMenuItem_Click);
            // 
            // ejemplo3ToolStripMenuItem
            // 
            this.ejemplo3ToolStripMenuItem.Name = "ejemplo3ToolStripMenuItem";
            this.ejemplo3ToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.ejemplo3ToolStripMenuItem.Text = "Ejemplo 3";
            this.ejemplo3ToolStripMenuItem.Click += new System.EventHandler(this.ejemplo3ToolStripMenuItem_Click);
            // 
            // acercaDeToolStripMenuItem
            // 
            this.acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            this.acercaDeToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.acercaDeToolStripMenuItem.Text = "Acerca de";
            this.acercaDeToolStripMenuItem.Click += new System.EventHandler(this.acercaDeToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.TextoTraducido,
            this.toolStripStatusLabel3,
            this.TxtNoTraducido});
            this.statusStrip1.Location = new System.Drawing.Point(0, 801);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(995, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BackColor = System.Drawing.Color.White;
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel1.ForeColor = System.Drawing.Color.Navy;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(97, 17);
            this.toolStripStatusLabel1.Text = "Lineas Traducidas:";
            // 
            // TextoTraducido
            // 
            this.TextoTraducido.BackColor = System.Drawing.Color.White;
            this.TextoTraducido.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextoTraducido.ForeColor = System.Drawing.Color.Red;
            this.TextoTraducido.Name = "TextoTraducido";
            this.TextoTraducido.Size = new System.Drawing.Size(13, 17);
            this.TextoTraducido.Text = "0";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.BackColor = System.Drawing.Color.White;
            this.toolStripStatusLabel3.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel3.ForeColor = System.Drawing.Color.Navy;
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(108, 17);
            this.toolStripStatusLabel3.Text = "Lineas no traducidas:";
            // 
            // TxtNoTraducido
            // 
            this.TxtNoTraducido.BackColor = System.Drawing.Color.White;
            this.TxtNoTraducido.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNoTraducido.ForeColor = System.Drawing.Color.Red;
            this.TxtNoTraducido.Name = "TxtNoTraducido";
            this.TxtNoTraducido.Size = new System.Drawing.Size(13, 17);
            this.TxtNoTraducido.Text = "0";
            // 
            // btnCompilar
            // 
            this.btnCompilar.BackColor = System.Drawing.Color.White;
            this.btnCompilar.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCompilar.ForeColor = System.Drawing.Color.Navy;
            this.btnCompilar.Location = new System.Drawing.Point(451, 164);
            this.btnCompilar.Name = "btnCompilar";
            this.btnCompilar.Size = new System.Drawing.Size(105, 58);
            this.btnCompilar.TabIndex = 16;
            this.btnCompilar.Text = "Compilar";
            this.btnCompilar.UseVisualStyleBackColor = false;
            this.btnCompilar.Click += new System.EventHandler(this.btnCompilar_Click);
            // 
            // lstlenguajetraducido
            // 
            this.lstlenguajetraducido.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstlenguajetraducido.FormattingEnabled = true;
            this.lstlenguajetraducido.ItemHeight = 14;
            this.lstlenguajetraducido.Location = new System.Drawing.Point(577, 164);
            this.lstlenguajetraducido.Name = "lstlenguajetraducido";
            this.lstlenguajetraducido.Size = new System.Drawing.Size(395, 438);
            this.lstlenguajetraducido.TabIndex = 15;
            this.lstlenguajetraducido.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lstTraducido_MouseClick);
            this.lstlenguajetraducido.SelectedIndexChanged += new System.EventHandler(this.lstTraducido_SelectedIndexChanged);
            // 
            // lstlenguajeoriginal
            // 
            this.lstlenguajeoriginal.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstlenguajeoriginal.FormattingEnabled = true;
            this.lstlenguajeoriginal.ItemHeight = 14;
            this.lstlenguajeoriginal.Location = new System.Drawing.Point(23, 164);
            this.lstlenguajeoriginal.Name = "lstlenguajeoriginal";
            this.lstlenguajeoriginal.Size = new System.Drawing.Size(401, 438);
            this.lstlenguajeoriginal.TabIndex = 14;
            this.lstlenguajeoriginal.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lstOriginal_MouseClick);
            this.lstlenguajeoriginal.SelectedIndexChanged += new System.EventHandler(this.lstOriginal_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(631, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(280, 23);
            this.label4.TabIndex = 13;
            this.label4.Text = "Lenguaje Visual Basic traducido";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(160, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(156, 23);
            this.label3.TabIndex = 12;
            this.label3.Text = "Lenguaje original";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(378, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(273, 55);
            this.label2.TabIndex = 11;
            this.label2.Text = "Compilador";
            // 
            // lst_Errores
            // 
            this.lst_Errores.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lst_Errores.HideSelection = false;
            this.lst_Errores.Location = new System.Drawing.Point(23, 608);
            this.lst_Errores.Name = "lst_Errores";
            this.lst_Errores.Size = new System.Drawing.Size(949, 190);
            this.lst_Errores.TabIndex = 17;
            this.lst_Errores.UseCompatibleStateImageBehavior = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Navy;
            this.ClientSize = new System.Drawing.Size(995, 823);
            this.Controls.Add(this.lst_Errores);
            this.Controls.Add(this.btnCompilar);
            this.Controls.Add(this.lstlenguajetraducido);
            this.Controls.Add(this.lstlenguajeoriginal);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lenguajeOriginalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lenguajeTraducidoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salidaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serviciosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acercaDeToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel TxtNoTraducido;
        private System.Windows.Forms.Button btnCompilar;
        private System.Windows.Forms.ListBox lstlenguajetraducido;
        private System.Windows.Forms.ListBox lstlenguajeoriginal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem ejemplosToolStripMenuItem;
        private System.Windows.Forms.ListView lst_Errores;

        [DllImport("kernel32")] private static extern bool AllocConsole();
        [DllImport("kernel32.dll")] private static extern bool FreeConsole();
        public void DisplayContent(string Contenido)
        {
            AllocConsole();
            Console.Write(Contenido);
            Console.ReadLine();
            FreeConsole();
        }

        public bool DatosCorrectos(string TipoDato, string Valor)
        {
            bool EsCorrecto= false;
            switch (TipoDato)
            {
                case "entero":
                    if (int.TryParse(Valor, out int entero))            EsCorrecto = true;
                    else                                                EsCorrecto = false;
                    break;
                case "booleano":
                    if(Valor == "verdadero" || Valor=="falso")           EsCorrecto = true;
                    else                                                EsCorrecto = false;
                    break;

                case "smallint":
                    if (byte.TryParse(Valor, out byte flotante))        EsCorrecto= true;
                    else                                                EsCorrecto = false;
                    break;

                case "cadena":                      EsCorrecto = true;              break;

                default:                            EsCorrecto = false;             break;
            }
            return EsCorrecto;
        }

        private System.Windows.Forms.ToolStripMenuItem ejemplosToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ejemplo1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ejemplo2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ejemplo3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel TextoTraducido;
    }
}

