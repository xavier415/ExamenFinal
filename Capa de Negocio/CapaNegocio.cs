using System;
using Microsoft.Data.SqlClient;
using Capa_de_Datos;
using Capa_de_Entidad;

namespace Capa_de_Negocio
{
    public class CapaNegocio
    {
        private readonly CapaDatos _capadatos;

        public CapaNegocio()
        {
            _capadatos = new CapaDatos();
        }

        // Registrar un nuevo usuario
        public void RegistrarUsuario(string nombre, string apellido, DateTime fechaNacimiento, string tipoUsuario, string usuario, string contraseña)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@nombre", nombre),
            new SqlParameter("@apellido", apellido),
            new SqlParameter("@fecha_nacimiento", fechaNacimiento),
            new SqlParameter("@tipo_usuario", tipoUsuario),
            new SqlParameter("@usuario", usuario),
            new SqlParameter("@contraseña", contraseña)
            };

            _capadatos.ExecuteNonQuery("sp_InsertarUsuario", parameters);
        }

        // Validar un usuario
        public bool ValidarUsuario(string usuario, string contraseña)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@usuario", usuario),
            new SqlParameter("@contraseña", contraseña)
            };

            using (var reader = _capadatos.ExecuteReader("sp_ValidarUsuario", parameters))
            {
                return reader.HasRows;
            }
        }

        // Registrar una visita
        public void RegistrarVisita(string nombre, string apellido, string carrera, string correo, int idEdificio, DateTime horaEntrada, DateTime horaSalida, string motivoVisita, string aulaDestino, byte[] foto)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@nombre", nombre),
            new SqlParameter("@apellido", apellido),
            new SqlParameter("@carrera", carrera),
            new SqlParameter("@correo", correo),
            new SqlParameter("@id_edificio", idEdificio),
            new SqlParameter("@hora_entrada", horaEntrada),
            new SqlParameter("@hora_salida", horaSalida),
            new SqlParameter("@motivo_visita", motivoVisita),
            new SqlParameter("@aula_destino", aulaDestino),
            new SqlParameter("@foto", foto)
            };

            _capadatos.ExecuteNonQuery("sp_InsertarVisita", parameters);
        }

        // Obtener edificios
        public List<Edificio> ObtenerEdificios()
        {
            List<Edificio> edificios = new List<Edificio>();

            using (var reader = _capadatos.ExecuteReader("SELECT id_edificio, nombre FROM Edificios", null))
            {
                while (reader.Read())   
                {
                    edificios.Add(new Edificio(
                        Convert.ToInt32(reader["id_edificio"]),
                        reader["nombre"].ToString()
                    ));
                }
            }

            return edificios;
        }


        // Obtener aulas por edificio
        public SqlDataReader ObtenerAulasPorEdificio(int idEdificio)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@id_edificio", idEdificio)
            };

            return _capadatos.ExecuteReader("SELECT id_aula, nombre_aula FROM Aulas WHERE id_edificio = @id_edificio", parameters);
        }
    }
}
