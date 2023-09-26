using System;
using System.Collections.Generic;

namespace PruebaTecnica2.Models
{
    public partial class Usuario
    {
        public string Id { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public int Estado { get; set; }
        public int Idrol { get; set; }

        public virtual Role IdrolNavigation { get; set; } = null!;
    }
}
