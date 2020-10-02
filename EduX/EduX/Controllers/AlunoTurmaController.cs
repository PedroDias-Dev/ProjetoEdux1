using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EduX.Domains;
using EduX.Interfaces;
using EduX.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EduX.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoTurmaController : ControllerBase
    {
        private readonly IAlunoTurmaRepository alunoTRepository;

        public AlunoTurmaController()
        {
            alunoTRepository = new AlunoTurmaRepository();
        }



        /// <summary>
        /// Mostra todas os alunos cadastrados
        /// </summary>
        /// <returns>Lista com todos os alunos</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                //lista de professores
                var aluno = alunoTRepository.Listar();

                //verifica se existe no conxtexto atual
                //caso nao exista ele retorna NoContext
                if (aluno.Count == 0)
                    return NoContent();

                //caso exista retorno Ok e o total de alunos cadastradss
                return Ok(new
                {
                    totalCount = aluno.Count,
                    data = aluno
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        // GET api/<AlunoTurmaController>/5
        /// <summary>
        /// Mostra um único aluno
        /// </summary>
        /// <param name="id">ID do aluno</param>
        /// <returns>Um aluno</returns>
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                //busca um aluno por id
                AlunoTurma aluno = alunoTRepository.BuscarPorId(id);

                //faz a verificacao no contexto para ver se o aluno foi encontrado
                //caso nao for encontrado o sistema retornara NotFound 
                if (aluno == null)
                    return NotFound();

                //se existir retorno vai passar o Ok e os dados do aluno
                return Ok(aluno);
            }
            catch (Exception ex)
            {
                //caso ocorra algum erro retorno BadRequest e a mensagem da exception
                return BadRequest(ex.Message);
            }
        }




        // POST api/<AlunoTurmaController>
        /// <summary>
        /// Cadastra um novo aluno
        /// </summary>
        /// <param name="alunoT">Objeto completo de aluno</param>
        /// <returns>Aluno cadastrado</returns>
        [HttpPost]
        public IActionResult Post([FromForm] AlunoTurma alunoT)
        {
            try
            {
                //adiciona um novo aluno
                alunoTRepository.Adicionar(alunoT);

                //retorna Ok se o aluno tiver sido cadastrado
                return Ok(alunoT);
            }
            catch (Exception ex)
            {
                //caso ocorra algum erro retorno BadRequest e a mensagem da exception
                return BadRequest(ex.Message);
            }
        }






        // PUT api/<AlunoTurmaController>/5
        /// <summary>
        /// Altera determinado aluno
        /// </summary>
        /// <param name="id">ID de aluno</param>
        /// <param name="alunoT">Objeto aluno com as alterações</param>
        /// <returns>Info do aluno alterado</returns>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromForm] AlunoTurma alunoT)
        {
            try
            {
                //edita aluno
                alunoTRepository.Editar(alunoT);

                //retorna o Ok com os dados do aluno
                return Ok(alunoT);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




        // DELETE api/<AlunoTurmaController>/5
        /// <summary>
        /// Exclui um aluno
        /// </summary>
        /// <param name="id">ID do aluno</param>
        /// <returns>ID excluído</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                //busca aluno pelo Id
                var alun = alunoTRepository.BuscarPorId(id);

                //verifica se o aluno existe
                //caso não exista retorna NotFound
                if (alun == null)
                    return NotFound();

                //caso exista remove o aluno
                alunoTRepository.Remover(id);
                //retorna Ok
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}