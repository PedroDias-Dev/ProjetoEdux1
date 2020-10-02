using EduX.Contexts;
using EduX.Domains;
using EduX.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduX.Repositories
{
    public class AlunoTurmaRepository : IAlunoTurmaRepository
    {

        private readonly EduxContext _ctx;
        public AlunoTurmaRepository()
        {
            _ctx = new EduxContext();
        }




        //adiciona um aluno
        public void Adicionar(AlunoTurma alunoT)
        {
            try
            {

                //adiciona o aluno no contexto
                _ctx.AlunoTurma.Add(alunoT);
                //salva as alteracoes
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        //busca um aluno por id
        public AlunoTurma BuscarPorId(Guid id)
        {
            try
            {
                return _ctx.AlunoTurma.Find(id);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }




        //busca um aluno por nome
        public List<AlunoTurma> BuscarPorNome(string nome)
        {
            try
            {
                return _ctx.AlunoTurma.Where(p => p.Matricula.Contains(nome)).ToList();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }




        //edita um aluno
        public void Editar(AlunoTurma alunoT)
        {
            try
            {
                //busca aluno pelo id
               AlunoTurma alunoTemp = BuscarPorId(alunoT.IdAlunoTurma);
                //verifica se o aluno existe no sistema, caso nao exista gera um exception
                if (alunoTemp == null)
                    throw new Exception("O Aluno inserido não foi encontrado no sistema. Verifique se foi digitado da maneira correta e tente novamente.");

                //caso exista altera suas propriedades
                alunoTemp.Matricula = alunoT.Matricula;



                //altera aluno no seu contexto
                _ctx.AlunoTurma.Update(alunoTemp);
                //salva suas alteraçoes
                _ctx.SaveChanges();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }






        public List<AlunoTurma> Listar()
        {
            try
            {
                return _ctx.AlunoTurma.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        //deleta um aluno
        public void Remover(Guid id)
        {
            try
            {
                //busca o aluno pelo id
                AlunoTurma alunoTemp = BuscarPorId(id);
                //verifica se o aluno existe no sistema, caso nao exista gera um exception
                if (alunoTemp == null)
                    throw new Exception("O Aluno inserido não foi encontrado no sistema. Verifique se foi digitado da maneira correta e tente novamente.");

                //remove o professor no contexto atual
                _ctx.AlunoTurma.Remove(alunoTemp);
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
