using EduX.Contexts;
using EduX.Domains;
using EduX.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduX.Repositories
{
    public class CurtidaRepository : ICurtidaRepository

    {



        private readonly EduxContext _ctx;
        public CurtidaRepository()
        {
            _ctx = new EduxContext();
        }



        //adiciona uma curtida
        public void Cadastrar(Curtida curtida)
        {
            try
            {

                //adiciona o objeto no contexto
                _ctx.Curtida.Add(curtida);
                //salva as alteracoes
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        //busca uma curtida por id
        public Curtida BuscarPorId(Guid id)
        {
            try
            {
                return _ctx.Curtida.Find(id);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<Curtida> BuscarPorIdDica(Guid? Iddica)
        {
            try
            {
                //return _ctx.Curtida.Find(Iddica);
                return _ctx.Curtida.Where(c => c.IdDica == (Iddica)).ToList();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }



        public List<Curtida> Listar()
        {
            try
            {
                return _ctx.Curtida.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }




        //deleta uma curtida
        public void Deletar(Guid id)
        {
            try
            {
                //busca uma curtida pelo id
                Curtida curtidaTemp = BuscarPorId(id);
                //verifica se a curtida existe no sistema, caso nao exista gera um exception
                if (curtidaTemp == null)
                    throw new Exception("A Curtida não foi encontrada no sistema. ");

                //remove curtida no contexto atual
                _ctx.Curtida.Remove(curtidaTemp);
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
