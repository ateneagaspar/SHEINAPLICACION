﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyecto_Aplicacion.formas
{
    public partial class FormAyuda : Form
    {
        public FormAyuda()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormCuenta cuenta = new FormCuenta();
            cuenta.Show();
            Hide();
        }
    }
}
