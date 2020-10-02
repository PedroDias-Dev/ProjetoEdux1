using EduX.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduX.Interfaces
{
    interface IAlunoTurmaRepository
    {
        List<AlunoTurma> Listar();
        AlunoTurma BuscarPorId(Guid id);
        List<AlunoTurma> BuscarPorNome(string nome);
        void Adicionar(AlunoTurma alunoT);
        void Editar(AlunoTurma alunoT);
        void Remover(Guid id);
    }
}
