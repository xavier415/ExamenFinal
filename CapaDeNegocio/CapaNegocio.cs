using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeDatos;
using CapaDeEntidad;
using Microsoft.Data.SqlClient;


namespace CapaDeNegocio
{
    public class CapaNegocio
    {
        private readonly CapaDatos capaDatos;

        public CapaNegocio()
        {
            capaDatos = new CapaDatos();
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

            capaDatos.ExecuteNonQuery("sp_InsertarUsuario", parameters);
        }

        // Validar un usuario
        public bool ValidarUsuario(string usuario, string contraseña)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@usuario", usuario),
            new SqlParameter("@contraseña", contraseña)
            };

            using (var reader = capaDatos.ExecuteReader("sp_ValidarUsuario", parameters))
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

            capaDatos.ExecuteNonQuery("sp_InsertarVisita", parameters);
        }

        // Obtener edificios
        public List<Edificio> ObtenerEdificios()
        {
            List<Edificio> edificios = new List<Edificio>();

            using (var reader = capaDatos.ExecuteReader("SELECT id_edificio, nombre FROM Edificios", null))
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
            List<Aula> aulas = new List<Aula>();

            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@id_edificio", idEdificio)
            };

            using (var reader = capaDatos.ExecuteReader("SELECT id_aula, nombre_aula FROM Aulas WHERE id_edificio = @id_edificio", parameters))
            {
                while (reader.Read())
                {
                    aulas.Add(new Aula(
                        Convert.ToInt32(reader["id_aula"]),
                        reader["nombre_aula"].ToString()
                    ));
                }
            }

            return aulas;
        }

        public DataTable ObtenerVisitas()
        {
            CapaDatos capaDatos = new CapaDatos();
            return capaDatos.ObtenerVisitas(); // Llama al método en la capa de datos
        }
    }
}
