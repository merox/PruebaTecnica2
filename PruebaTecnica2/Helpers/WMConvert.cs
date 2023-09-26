using PruebaTecnica2.Models;
using PruebaTecnica2.Models.DTO;

namespace PruebaTecnica2.Helpers
{
    public class WMConvert
    {
        public static UsuarioDTO ConvertToUserDTO(Usuario ob)
        {
            UsuarioDTO r = new UsuarioDTO()
            {
                Id = ob.Id,
                Nombre = ob.Nombre,
                Estado = ob.Estado,
                IdRol = ob.Idrol,
                NombreRol = ob.IdrolNavigation.Nombre
            };
            return r;
        }

        public static Usuario ConvertToUser(UsuarioDTO ob)
        {
            Usuario r = new Usuario()
            {
                Id = ob.Id,
                Nombre = ob.Nombre,
                Estado = ob.Estado,
                Idrol = ob.IdRol
            };
            return r;
        }
    }
}
