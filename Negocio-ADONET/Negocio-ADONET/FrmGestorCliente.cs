﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Entidades.Models;

namespace Negocio_ADONET
{
    public partial class FrmGestorCliente : Form
    {
        private Cliente cliente;
        public enum EGestorCliente { Alta, Modificacion };
        private EGestorCliente solicitud;
        public FrmGestorCliente(EGestorCliente solicitud)
        {
            InitializeComponent();
            this.solicitud = solicitud;
        }

        public Cliente Cliente { get => this.cliente; set => this.cliente = value; }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                int telefono = int.Parse(this.txtTelefono.Text);
                if(this.solicitud == EGestorCliente.Alta)
                {
                    this.cliente = new Cliente(this.txtNombre.Text,this.txtApellido.Text, telefono);
                    this.cliente.Direccion = new Direccion("Santa Fe", "San Lorenzo", "Aberdi 123");
                }
                else
                {
                    this.cliente = new Cliente(this.cliente.Id,this.txtNombre.Text, this.txtApellido.Text, telefono);

                }
     
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                this.DialogResult = DialogResult.Cancel;
            }




        }

        private void FrmGestorCliente_Load(object sender, EventArgs e)
        {
            if (this.solicitud == EGestorCliente.Modificacion)
            {
                this.txtApellido.Text = this.cliente.Apellido;
                this.txtNombre.Text = this.cliente.Nombre;
                this.txtTelefono.Text = this.cliente.Telefono.ToString();
                this.txtDireccion.Text = this.cliente.Direccion.Calle;
            }
            else
            {
                foreach (Control item in this.Controls)
                {
                    if (item is TextBox)
                    {
                        item.Text = String.Empty;
                    }
                }
            }
        }
    }
}
