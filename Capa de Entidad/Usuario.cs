namespace Capa_de_Entidad
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string TipoUsuario { get; set; } // "Administrador" o "General"
        public string UsuarioLogin { get; set; }
        public string Contraseña { get; set; }

        // Constructor por defecto
        public Usuario() { }

        // Constructor con parámetros
        public Usuario(int idUsuario, string nombre, string apellido, DateTime fechaNacimiento, string tipoUsuario, string usuarioLogin, string contraseña)
        {
            IdUsuario = idUsuario;
            Nombre = nombre;
            Apellido = apellido;
            FechaNacimiento = fechaNacimiento;
            TipoUsuario = tipoUsuario;
            UsuarioLogin = usuarioLogin;
            Contraseña = contraseña;
        }
    }
}
