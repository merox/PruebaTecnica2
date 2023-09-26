using System;
using System.Collections.Generic;

namespace PruebaTecnica2.Models
{
    public partial class Role
    {
        public Role()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public int Estado { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
