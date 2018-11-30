using CapaDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmAnadirUsuario : Form
    {
        public frmAnadirUsuario()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GestorUsuario gestorUsuario = new GestorUsuario();
            gestorUsuario.DarAltaUsuario(new Usuario(0,"654","Juanillo","holita.jpg"));
        }
    }
}
