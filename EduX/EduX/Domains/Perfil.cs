using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;

namespace EduX.Domains
{
    public partial class Perfil
    {
        public Perfil()
        {
            //Usuario = new HashSet<Usuario>();
            IdPerfil = Guid.NewGuid();
        }
        //public string Nome { get; set; }
        public Guid IdPerfil { get; set; }
        public string Permissao { get; set; }

        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
