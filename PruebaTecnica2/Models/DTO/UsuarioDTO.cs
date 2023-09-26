namespace PruebaTecnica2.Models.DTO
{
    public class UsuarioDTO
    {
        public String Id { get; set; } = "";
        public String Nombre { get; set; } = "";
        public int Estado { get; set; }
        public int IdRol { get; set; }
        public String NombreRol { get; set; } = "";
    }
}
