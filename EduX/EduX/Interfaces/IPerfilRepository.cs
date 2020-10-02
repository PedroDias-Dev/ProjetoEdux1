using EduX.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduX.Interfaces
{
    interface IPerfilRepository
    {
        List<Perfil> Listar();
        Perfil BuscarPorId(Guid id);
        List<Perfil> BuscarPorNome(string nome);
        void Adicionar(Perfil perfil);
        void Editar(Perfil perfil);
        void Remover(Guid id);
    }
}
