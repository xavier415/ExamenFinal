using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_de_Entidad
{
   public class Edificio
    {
        public int IdEdificio { get; set; }
        public string Nombre { get; set; }

        // Constructor por defecto
        public Edificio() { }

        // Constructor con parámetros
        public Edificio(int idEdificio, string nombre)
        {
            IdEdificio = idEdificio;
            Nombre = nombre;
        }
    }
}
