﻿
namespace Prueba
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.etiquetaAviso1 = new Ejercicio2.EtiquetaAviso();
            this.SuspendLayout();
            // 
            // etiquetaAviso1
            // 
            this.etiquetaAviso1.ColorFinal = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.etiquetaAviso1.ColorInicio = System.Drawing.Color.DodgerBlue;
            this.etiquetaAviso1.Degradado = true;
            this.etiquetaAviso1.ImagenMarca = ((System.Drawing.Image)(resources.GetObject("etiquetaAviso1.ImagenMarca")));
            this.etiquetaAviso1.Location = new System.Drawing.Point(135, 66);
            this.etiquetaAviso1.Marca = Ejercicio2.eMarca.Circulo;
            this.etiquetaAviso1.Name = "etiquetaAviso1";
            this.etiquetaAviso1.Size = new System.Drawing.Size(101, 23);
            this.etiquetaAviso1.TabIndex = 0;
            this.etiquetaAviso1.Text = "etiquetaAviso1";
            this.etiquetaAviso1.ClickEnMarca += new System.EventHandler(this.etiquetaAviso1_ClickEnMarca);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.etiquetaAviso1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Ejercicio2.EtiquetaAviso etiquetaAviso1;
    }
}

