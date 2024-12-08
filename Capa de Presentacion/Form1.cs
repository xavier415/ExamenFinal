using System;
using System.Windows.Forms;
using CapaDeDatos;
using CapaDeNegocio;

namespace Capa_de_Presentacion
{
    public partial class Form1 : Form
    {
        private readonly CapaNegocio capaDeNegocio;
        public Form1()
        {
            InitializeComponent();
            capaDeNegocio = new CapaNegocio();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string contraseña = txtContraseña.Text;

            if (usuario == "UsuarioGeneral" && contraseña == "1234")
            {
                // Usuario General: Solo puede observar datos.
                FormUsuarioGeneral formGeneral = new FormUsuarioGeneral();
                formGeneral.Show();
                this.Hide();
            }
            else if (usuario == "Administrador" && contraseña == "123456789")
            {
                // Administrador: Accede a todas las funcionalidades.
                FormAdministrador formAdmin = new FormAdministrador();
                formAdmin.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos. Por favor, inténtelo de nuevo.", "Error de Autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
