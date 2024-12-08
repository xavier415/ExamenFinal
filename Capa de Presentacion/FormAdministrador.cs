using CapaDeEntidad;
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
    public partial class FormAdministrador : Form
    {
        public FormAdministrador()
        {
            InitializeComponent();
        }

        private void FormAdministrador_Load(object sender, EventArgs e)
        {
            CargarVisitas();
        }

        private void CargarVisitas()
        {
            try
            {
                dgvVisitas.DataSource = negocioVisitas.ObtenerVisitas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Insertar_Click(object sender, EventArgs e)
        {
            try
            {
                // Crear una nueva visita
                Visita visita = new Visita
                {
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    Carrera = txtCarrera.Text,
                    Correo = txtCorreo.Text,
                    IdEdificio = Convert.ToInt32(cmbEdificio.SelectedValue),
                    HoraEntrada = dtpHoraEntrada.Value,
                    HoraSalida = dtpHoraSalida.Value,
                    MotivoVisita = txtMotivo.Text,
                    AulaDestino = cmbAula.SelectedItem.ToString(),
                    Foto = null // Aquí puedes implementar la funcionalidad para capturar la foto
                };

                // Insertar la visita
                negocioVisitas.InsertarVisita(visita);
                MessageBox.Show("Visita registrada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarVisitas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar la visita: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Modificar_Click(object sender, EventArgs e)
        {
            try
            {
                // Crear una visita con los datos modificados
                Visita visita = new Visita
                {
                    IdVisita = Convert.ToInt32(txtIdVisita.Text),
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    Carrera = txtCarrera.Text,
                    Correo = txtCorreo.Text,
                    IdEdificio = Convert.ToInt32(cmbEdificio.SelectedValue),
                    HoraEntrada = dtpHoraEntrada.Value,
                    HoraSalida = dtpHoraSalida.Value,
                    MotivoVisita = txtMotivo.Text,
                    AulaDestino = cmbAula.SelectedItem.ToString(),
                    Foto = null // Aquí puedes implementar la funcionalidad para capturar la foto
                };

                // Modificar la visita
                negocioVisitas.ModificarVisita(visita);
                MessageBox.Show("Visita modificada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarVisitas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar la visita: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                // Eliminar una visita por su ID
                int idVisita = Convert.ToInt32(txtIdVisita.Text);
                negocioVisitas.EliminarVisita(idVisita);
                MessageBox.Show("Visita eliminada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarVisitas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar la visita: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Buscar_Click(object sender, EventArgs e)
        {
            try
            {
                // Buscar visitas según el criterio ingresado
                string criterio = txtCriterioBusqueda.Text;
                dgvVisitas.DataSource = negocioVisitas.BuscarVisitas(criterio);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar visitas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
