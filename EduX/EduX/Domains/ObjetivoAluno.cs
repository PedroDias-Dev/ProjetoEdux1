using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduX.Domains
{
    public partial class ObjetivoAluno
    {
        public Guid IdObjetivoAluno { get; set; }
        [NotMapped]
        public string Nome { get; set; }
        public DateTime? DataAlcancado { get; set; }
        public Guid? IdAlunoTurma { get; set; }
        public Guid? IdObjetivo { get; set; }

        public virtual AlunoTurma IdAlunoTurmaNavigation { get; set; }
        public virtual Objetivo IdObjetivoNavigation { get; set; }


        public ObjetivoAluno()
        {
            IdObjetivoAluno = Guid.NewGuid();
        }
    }
}
