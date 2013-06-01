using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoGitHubEquipoA
{
    public partial class FormBienvenida : Form
    {
        public FormBienvenida()
        {
            InitializeComponent();
        }

        //INICIA EL FORMULARIO DE ASIGNATURAS (ALVARO)
        private void button2_Click(object sender, EventArgs e)
        {
            FormAlvaro formAsignaturas = new FormAlvaro();
            formAsignaturas.Show();
        }
    }
}
