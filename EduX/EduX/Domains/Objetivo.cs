using System;
using System.Collections.Generic;

namespace EduX.Domains
{
    public partial class Objetivo
    {
        public Objetivo()
        {
            ObjetivoAluno = new HashSet<ObjetivoAluno>();
            IdObjetivo = Guid.NewGuid();
        }

        public Guid IdObjetivo { get; set; }
        public string Descricao { get; set; }
        public Guid? IdCategoria { get; set; }

        public virtual Categoria IdCategoriaNavigation { get; set; }
        public virtual ICollection<ObjetivoAluno> ObjetivoAluno { get; set; }
    }
}
