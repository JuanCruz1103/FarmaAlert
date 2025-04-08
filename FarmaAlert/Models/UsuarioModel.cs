namespace FarmaAlert.Models
{
    public class UsuarioModel
    {
        public string Nombre { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Contrasena { get; set; }
        public string Rol { get; set; }
        public DateTime FechaCreacionUsuario { get; set; } = DateTime.UtcNow; 
    }
}
