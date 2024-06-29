using Clases;
using Clases.Excepciones;
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
    public partial class FrmPrincipal : Form
    {
        Empresa miEmpresa;

        public FrmPrincipal()
        {
            InitializeComponent();
            miEmpresa = new Empresa("UTN221");
            Desarrollador desarrollador1 = new Desarrollador(1, "Pepe", "Gomez", 25, "sistemas", 1500, 30);
            Gerente gerente1 = new Gerente(2, "Mari", "Ruis", 30, "Gerencia", 2500, 10);
            Desarrollador desarrollador2 = new Desarrollador(3, "Maria", "Gomez", 26, "sistemas", 1400, 20);
            Desarrollador desarrollador3 = new Desarrollador(4, "Pepe", "Gomez", 25, "sistemas", 1500, 30);
            Gerente gerente2 = new Gerente(5, "Lula", "Gomez", 40, "Gerencia", 6000, 1);

            miEmpresa.AñadirEmpleado(desarrollador1);
            miEmpresa.AñadirEmpleado(desarrollador2);
            miEmpresa.AñadirEmpleado(desarrollador3);
            miEmpresa.AñadirEmpleado(gerente1);
            miEmpresa.AñadirEmpleado(gerente2);
        }

        private void cargarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FrmDesarrollador miFormulario = new FrmDesarrollador();
                if (miFormulario.ShowDialog() == DialogResult.OK)
                {
                    miEmpresa.AñadirEmpleado(miFormulario.DesarrolladorFormulario);
                    // se puede agregar un messagebox de empleado cargado exitosamente
                }
                else
                {
                    MessageBox.Show("Accion cancelada por el usuario. Desarrollador no cargado");
                }
            }
            catch (EmpleadoNoEncotradoException ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            

        }

        private void mostrarTodosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMostrar mostrar = new FrmMostrar(miEmpresa); //comunicacion entre formularios, pasando miEmpresa en el constructor
            mostrar.Show();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {

        }
    }
}
