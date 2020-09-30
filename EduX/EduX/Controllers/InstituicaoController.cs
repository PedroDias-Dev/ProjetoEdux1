using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EduX.Contexts;
using EduX.Domains;
using EduX.Repositories;
using EduX.Interfaces;

namespace EduX.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstituicaoController : ControllerBase
    {
        private readonly IInstituicaoRepository _instituicaoRepository;

        public InstituicaoController()
        {
            _instituicaoRepository = new InstituicaoRepository();
        }


        // GET: api/Instituicao
        /// <summary>
        /// Mostra todas as instuições cadastradas
        /// </summary>
        /// <returns>Lista com todas as instuições</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                // Lista as instituiçoes
                var instituicao = _instituicaoRepository.Listar();

                //Verifica se existe instituiçoes, caso não exista 
                //NoContent - Sem conteudo 
                if (instituicao.Count == 0)
                    return NoContent();

                //Caso exista retorna "ok" e as instituiçoes
                return Ok(instituicao);
            }
            catch (Exception)
            {
                //caso ocorra algum erro retorna mensagem de erro 
                return BadRequest(new
                {
                    stausCode = 400,
                    error = "Ocorreu um erro no endpoint Get/instituições, envie um email para email@gmail.com informando"
                });
            }
        }



        // GET: api/Instituicao/5
        /// <summary>
        /// Mostra uma única instituição
        /// </summary>
        /// <param name="id">ID da instituição</param>
        /// <returns>Uma instituição</returns>
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                //busca o jogador
                var instituicao = _instituicaoRepository.BuscarPorId(id);

                //Verifica se existe jogadores 
                //caso não exista retorna NotFound
                if (instituicao == null)
                    return NotFound();

                //Caso exista retorna "ok" e o jogador
                return Ok(instituicao);
            }
            catch (Exception ex)
            {
                //caso ocorra algum erro retorna mensagem de erro 
                return BadRequest(ex.Message);
            }
        }



        // PUT: api/Instituicao/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        /// <summary>
        /// Altera determinada instituição
        /// </summary>
        /// <param name="id">ID da instituição</param>
        /// <param name="instituicao">Objeto instituição com suas as alterações</param>
        /// <returns>Info da instituição alterada</returns>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id,[FromForm] Instituicao instituicao)
        {
            try
            {
                var instituicaoTemp = _instituicaoRepository.BuscarPorId(id);

                if (instituicaoTemp == null)
                    return NotFound();

                instituicao.IdInstituicao = id;
                _instituicaoRepository.Alterar(instituicao);

                return Ok(instituicao);
            }
            catch (Exception ex)
            {
                //caso ocorra algum erro retorna mensagem de erro 
                return BadRequest(ex.Message);
            }
        }





        // POST: api/Instituicao
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        /// <summary>
        /// Cadastra uma nova instituição
        /// </summary>
        /// <param name="instituicao">Objeto completo de instituição</param>
        /// <returns>Instituição cadastrada</returns>
        [HttpPost]
        public IActionResult Post([FromForm] Instituicao instituicao)
        {
            try
            {
                _instituicaoRepository.Cadastrar(instituicao);


                return Ok(instituicao);
            }
            catch (Exception ex)
            {
                //caso ocorra algum erro retorna mensagem de erro 
                return BadRequest(ex.Message);
            }
        }




        // DELETE: api/Instituicao/5
        /// <summary>
        /// Exclui uma instituição
        /// </summary>
        /// <param name="id">ID da instituição</param>
        /// <returns>ID excluído</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _instituicaoRepository.Deletar(id);
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
