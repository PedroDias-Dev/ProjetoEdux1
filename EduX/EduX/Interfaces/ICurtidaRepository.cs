using EduX.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduX.Interfaces
{
    interface ICurtidaRepository
    {
        public void Cadastrar(Curtida curtida);
        public void Deletar(Guid id);
        public List<Curtida> Listar();

        public Curtida BuscarPorId(Guid id);

    }
}
