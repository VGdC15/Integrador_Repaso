﻿using Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Integrador_Repaso
{
    public partial class FrmMostrar : Form
    {
        Empresa empresaFormulario;
        public FrmMostrar(Empresa miEmpresa)
        {
            InitializeComponent();
            empresaFormulario = miEmpresa;
        }



        private void FrmMostrar_Load(object sender, EventArgs e)
        {

        }

        private void btnTodos_Click(object sender, EventArgs e)
        {
            foreach (Empleado emp in empresaFormulario.Empleados)
            {
                lstMostrar.Items.Add(emp.MostrarInformacion()); //devuelve la info de todos

            }
        }

        private void btnDesarrolladores_Click(object sender, EventArgs e)
        {
            foreach (Empleado emp in empresaFormulario.Empleados)
            {
                if (emp is Desarrollador)
                {
                    lstMostrar.Items.Add(emp.MostrarInformacion()); //devuelve la info de todos
                }


            }
        }

        private void btnGerentes_Click(object sender, EventArgs e)
        {
            foreach (Empleado emp in empresaFormulario.Empleados)
            {
                if (emp is Gerente)
                {
                    lstMostrar.Items.Add(emp.MostrarInformacion()); //devuelve la info de todos
                }


            }

        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {
            string ultimo = empresaFormulario.MostrarUltimoEmpleado();
            MessageBox.Show(ultimo);

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);


            Empleado emp = empresaFormulario.BuscarPorId(id);
            MessageBox.Show(emp.MostrarInformacion());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // polimorfismo: identifico de que tipo es el objeto y desencapsulando el objeto haciendolo más específico
            // convierto el empleado en algo mas especifico, como un gerente y de ahi accedo a los metodos propios de gerente
            foreach(Empleado emp in empresaFormulario.Empleados)
            {
                if(emp is Gerente)
                {
                    Gerente g = (Gerente)emp;
                    string cadena = g.AsignarProyecto();
                    lstMostrar.Items.Add(cadena);
                }
            }
        }
    }
}
