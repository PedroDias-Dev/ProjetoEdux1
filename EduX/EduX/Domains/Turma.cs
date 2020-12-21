using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EduX.Domains
{
    public partial class Turma
    {
        public Turma()
        {
            AlunoTurma = new HashSet<AlunoTurma>();
            ProfessorTurma = new HashSet<ProfessorTurma>();
            IdTurma = Guid.NewGuid();
        }

        public Guid IdTurma { get; set; }
        public string Descricao { get; set; }
        public Guid? IdCurso { get; set; }

        [JsonIgnore]
        public virtual Curso IdCursoNavigation { get; set; }

        [JsonIgnore]
        public virtual ICollection<AlunoTurma> AlunoTurma { get; set; }

        [JsonIgnore]
        public virtual ICollection<ProfessorTurma> ProfessorTurma { get; set; }
    }
}
