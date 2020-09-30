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
    public class CursoController : ControllerBase
    {
        private readonly ICursoRepository _cursoRepository;

        public CursoController()
        {
            _cursoRepository = new CursoRepository();
        }

        // GET: api/Curso
        /// <summary>
        /// Mostra todos os cursos cadastrados
        /// </summary>
        /// <returns>Lista com todos os cursos</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                // Lista as instituiçoes
                var curso = _cursoRepository.Listar();

                //Verifica se existe instituiçoes, caso não exista 
                //NoContent - Sem conteudo 
                if (curso.Count == 0)
                    return NoContent();

                //Caso exista retorna "ok" e as instituiçoes
                return Ok(curso);
            }
            catch (Exception)
            {
                //caso ocorra algum erro retorna mensagem de erro 
                return BadRequest(new
                {
                    stausCode = 400,
                    error = "Ocorreu um erro no endpoint Get/cursos, envie um email para email@gmail.com informando"
                });
            }
        }



        // GET: api/Curso/5
        /// <summary>
        /// Mostra um único cuso
        /// </summary>
        /// <param name="id">ID de curso</param>
        /// <returns>Um curso</returns>
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                //busca o jogador
                var curso = _cursoRepository.BuscarPorId(id);

                //Verifica se existe jogadores 
                //caso não exista retorna NotFound
                if (curso == null)
                    return NotFound();

                //Caso exista retorna "ok" e o jogador
                return Ok(curso);
            }
            catch (Exception ex)
            {
                //caso ocorra algum erro retorna mensagem de erro 
                return BadRequest(ex.Message);
            }
        }




        // PUT: api/Curso/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        /// <summary>
        /// Altera determinado curso
        /// </summary>
        /// <param name="id">ID do curso</param>
        /// <param name="curso">Objeto curso com suas alterações</param>
        /// <returns>Info do curso alterado</returns>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id,[FromForm] Curso curso)
        {
            try
            {
                var cursoTemp = _cursoRepository.BuscarPorId(id);

                if (cursoTemp == null)
                    return NotFound();

                curso.IdInstituicao = id;
                _cursoRepository.Alterar(curso);

                return Ok(curso);
            }
            catch (Exception ex)
            {
                //caso ocorra algum erro retorna mensagem de erro 
                return BadRequest(ex.Message);
            }
        }   



        // POST: api/Curso
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        /// <summary>
        /// Cadastra um novo curso
        /// </summary>
        /// <param name="curso">Objeto completo de curso</param>
        /// <returns>Curso cadastrado</returns>
        [HttpPost]
        public IActionResult Post([FromForm] Curso curso)
        {
            try
            {
                _cursoRepository.Cadastrar(curso);


                return Ok(curso);
            }
            catch (Exception ex)
            {
                //caso ocorra algum erro retorna mensagem de erro 
                return BadRequest(ex.Message);
            }
        }



        // DELETE: api/Curso/5
        /// <summary>
        /// Exclui um curso
        /// </summary>
        /// <param name="id">ID do curso</param>
        /// <returns>ID excluído</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _cursoRepository.Deletar(id);
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
