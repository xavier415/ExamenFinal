using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_de_Entidad
{
    public class Aula
    {
        public int IdAula { get; set; }
        public int IdEdificio { get; set; }
        public string NombreAula { get; set; }

        // Constructor por defecto
        public Aula() { }

        // Constructor con parámetros
        public Aula(int idAula, int idEdificio, string nombreAula)
        {
            IdAula = idAula;
            IdEdificio = idEdificio;
            NombreAula = nombreAula;
        }
    }
}
