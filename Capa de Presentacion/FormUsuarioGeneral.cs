using CapaDeNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capa_de_Presentacion
{
    public partial class FormUsuarioGeneral : Form
    {
        public FormUsuarioGeneral()
        {
            InitializeComponent();
        }

        private void FormUsuarioGeneral_Load(object sender, EventArgs e)
        {
            // Llamar a la capa de negocio para cargar los datos.
            CapaNegocio negocioVisitas = new CapaNegocio();
            dgvVisitas.DataSource = negocioVisitas.ObtenerVisitas(); // Método que retorna la lista de visitas.
        }

        private void dgvVisitas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
