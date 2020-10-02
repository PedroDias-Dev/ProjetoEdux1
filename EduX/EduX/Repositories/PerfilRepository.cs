using EduX.Contexts;
using EduX.Domains;
using EduX.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduX.Repositories
{
    public class PerfilRepository : IPerfilRepository
    {
        private readonly EduxContext _ctx;
        public PerfilRepository()
        {
            _ctx = new EduxContext();
        }





        //adiciona um perfil
        public void Adicionar(Perfil perfil)
        {
            try
            {

                //adiciona o objeto no contexto
                _ctx.Perfil.Add(perfil);
                //salva as alteracoes
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }







        //busca um perfil por id
        public Perfil BuscarPorId(Guid id)
        {
            try
            {
                return _ctx.Perfil.Find(id);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }









        //busca um perfil por nome
        public List<Perfil> BuscarPorNome(string nome)
        {
            try
            {
                return _ctx.Perfil.Where(p => p.Permissao.Contains(nome)).ToList();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }







        //edita um perfil
        public void Editar(Perfil perfil)
        {
            try
            {
                //busca um perfil pelo id
                Perfil perfilTemp = BuscarPorId(perfil.IdPerfil);
                //verifica se o perfil existe no sistema, caso nao exista gera um exception
                if (perfilTemp == null)
                    throw new Exception("O Perfil inserida não foi encontrado no sistema. Verifique se foi digitado da maneira correta e tente novamente.");

                //caso exista altera suas propriedades
                perfilTemp.Permissao = perfil.Permissao;



                //altera perfil no seu contexto
                _ctx.Perfil.Update(perfilTemp);
                //salva suas alteraçoes
                _ctx.SaveChanges();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }










        public List<Perfil> Listar()
        {
            try
            {
                return _ctx.Perfil.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }









        //deleta um perfil
        public void Remover(Guid id)
        {
            try
            {
                //busca o perfil pelo id
                Perfil perfilTemp = BuscarPorId(id);
                //verifica se o perfil existe no sistema, caso nao exista gera um exception
                if (perfilTemp == null)
                    throw new Exception("O Perfil inserido não foi encontrado no sistema. Verifique se foi digitado da maneira correta e tente novamente.");

                //remove perfil no contexto atual
                _ctx.Perfil.Remove(perfilTemp);
                //salva as alteraçoes
                _ctx.SaveChanges();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
    }
}
