using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EduX.Contexts;
using EduX.Domains;
using EduX.Interfaces;
using EduX.Repositories;

namespace EduX.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObjetivoAlunoController : ControllerBase
    {
        private readonly IObjetivoAlunoRepository _objetivoAlunoRepository;

        public ObjetivoAlunoController()
        {
            _objetivoAlunoRepository = new ObjetivoAlunoRepository();
        }


        // GET: api/ObjetivoAluno
        /// <summary>
        /// Mostra todos os objetivos, direcionados aos alunos, cadastrados
        /// </summary>
        /// <returns>Lista com todos os objetivos</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                // Lista as instituiçoes
                var objetivoAluno = _objetivoAlunoRepository.Listar();

                //Verifica se existe objetivos, caso não exista 
                //NoContent - Sem conteudo 
                if (objetivoAluno.Count == 0)
                    return NoContent();

                //Caso exista retorna "ok" e os objetivos
                return Ok(objetivoAluno);
            }
            catch (Exception)
            {
                //caso ocorra algum erro retorna mensagem de erro 
                return BadRequest(new
                {
                    stausCode = 400,
                    error = "Ocorreu um erro no endpoint Get/objetivosAlunos, envie um email para email@gmail.com informando"
                });
            }
        }


        // GET: api/ObjetivoAluno/5
        /// <summary>
        /// Mostra um único objetivo
        /// </summary>
        /// <param name="id">ID do objetivo</param>
        /// <returns>Um objetivo</returns>
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                //busca o jogador
                var objetivoAluno = _objetivoAlunoRepository.BuscarPorId(id);

                //Verifica se existe objetivos 
                //caso não exista retorna NotFound
                if (objetivoAluno == null)
                    return NotFound();

                //Caso exista retorna "ok" e o objetivo
                return Ok(objetivoAluno);
            }
            catch (Exception ex)
            {
                //caso ocorra algum erro retorna mensagem de erro 
                return BadRequest(ex.Message);
            }
        }



        // PUT: api/ObjetivoAluno/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        /// <summary>
        /// Altera determinado objetivo
        /// </summary>
        /// <param name="id">ID do objetivo</param>
        /// <param name="objetivoAluno">Objeto objetivo com suas alterações</param>
        /// <returns>Info do objetivo alterado</returns>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id,[FromBody] ObjetivoAluno objetivoAluno)
        {
            try
            {
                var objetivoAlunoTemp = _objetivoAlunoRepository.BuscarPorId(id);

                if (objetivoAlunoTemp == null)
                    return NotFound();

                objetivoAluno.IdObjetivoAluno = id;
                _objetivoAlunoRepository.Alterar(objetivoAluno);

                return Ok(objetivoAluno);
            }
            catch (Exception ex)
            {
                //caso ocorra algum erro retorna mensagem de erro 
                return BadRequest(ex.Message);
            }
        }



        // POST: api/ObjetivoAluno
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        /// <summary>
        /// Cadastra um novo objetivo
        /// </summary>
        /// <param name="objetivoAluno">Objeto completo de objetivo</param>
        /// <returns>Objetivo cadastrado</returns>
        [HttpPost]
        public IActionResult Post([FromBody] ObjetivoAluno objetivoAluno)
        {
            try
            {
                _objetivoAlunoRepository.Cadastrar(objetivoAluno);


                return Ok(objetivoAluno);
            }
            catch (Exception ex)
            {
                //caso ocorra algum erro retorna mensagem de erro 
                return BadRequest(ex.Message);
            }
        }



        // DELETE: api/ObjetivoAluno/5
        /// <summary>
        /// Exclui um objetivo
        /// </summary>
        /// <param name="id">ID do objetivo</param>
        /// <returns>ID excluído</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _objetivoAlunoRepository.Deletar(id);
                return Ok(id);
            }
            catch (Exception ex)
            {
                //caso ocorra algum erro retorna mensagem de erro 
                return BadRequest(ex.Message);
            }
        }
    }
}
