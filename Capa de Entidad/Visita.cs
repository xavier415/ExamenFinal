    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_de_Entidad
{
    public class Visita
    {
        public int IdVisita { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Carrera { get; set; }
        public string Correo { get; set; }
        public int IdEdificio { get; set; }
        public DateTime HoraEntrada { get; set; }
        public DateTime HoraSalida { get; set; }
        public string MotivoVisita { get; set; }
        public string AulaDestino { get; set; }
        public byte[] Foto { get; set; } // Foto en formato binario

        // Constructor por defecto
        public Visita() { }

        // Constructor con parámetros
        public Visita(int idVisita, string nombre, string apellido, string carrera, string correo, int idEdificio, DateTime horaEntrada, DateTime horaSalida, string motivoVisita, string aulaDestino, byte[] foto)
        {
            IdVisita = idVisita;
            Nombre = nombre;
            Apellido = apellido;
            Carrera = carrera;
            Correo = correo;
            IdEdificio = idEdificio;
            HoraEntrada = horaEntrada;
            HoraSalida = horaSalida;
            MotivoVisita = motivoVisita;
            AulaDestino = aulaDestino;
            Foto = foto;
        }
    }
}
