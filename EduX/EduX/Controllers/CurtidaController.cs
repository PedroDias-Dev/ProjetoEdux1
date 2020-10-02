using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EduX.Domains;
using EduX.Interfaces;
using EduX.Repositories;
//using EduX.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EduX.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurtidaController : ControllerBase
    {
        private readonly ICurtidaRepository curtidaRepository;

        public CurtidaController()
        {
            curtidaRepository = new CurtidaRepository();
        }

        /// <summary>
        /// Mostra todas as curtidas cadastradas
        /// </summary>
        /// <returns>Lista com todas as curtidas</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                //lista de categorias
                var curtidas = curtidaRepository.Listar();

                //verifica se existe no conxtexto atual
                //caso nao exista ele retorna NoContext
                if (curtidas.Count == 0)
                    return NoContent();

                //caso exista retorno Ok e o total de curtidas cadastradas
                return Ok(new
                {
                    totalCount = curtidas.Count,
                    data = curtidas
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        // GET api/<CurtidaController>/5
        /// <summary>
        /// Mostra uma única curtida
        /// </summary>
        /// <param name="id">ID da curtida</param>
        /// <returns>Uma curtida</returns>
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                //busca uma categoria por id
                Curtida curtid = curtidaRepository.BuscarPorId(id);

                //faz a verificacao no contexto para ver se a curtida foi encontrada
                //caso nao for encontrada o sistema retornara NotFound 
                if (curtid == null)
                    return NotFound();

                //se existir retorno vai passar o Ok e os dados da curtida
                return Ok(curtid);
            }
            catch (Exception ex)
            {
                //caso ocorra algum erro retorno BadRequest e a mensagem da exception
                return BadRequest(ex.Message);
            }
        }


        // POST api/<CurtidaController>
        /// <summary>
        /// Cadastra uma nova curtida
        /// </summary>
        /// <param name="curtida">Objeto completo de curtida</param>
        /// <returns>Curtida cadastrada</returns>
        [HttpPost]
        public IActionResult Post([FromForm] Curtida curtida)
        {
            try
            {
                //adiciona uma nova curtida
                curtidaRepository.Cadastrar(curtida);

                //retorna Ok se a curtida tiver sido cadastrada
                return Ok(curtida);
            }
            catch (Exception ex)
            {
                //caso ocorra algum erro retorno BadRequest e a mensagem da exception
                return BadRequest(ex.Message);
            }
        }



  
        


        // DELETE api/<CurtidaController>/5
        /// <summary>
        /// Exclui uma curtida
        /// </summary>
        /// <param name="id">ID da curtida</param>
        /// <returns>ID excluído</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                //busca categoria pelo Id
                var curtid = curtidaRepository.BuscarPorId(id);

                //verifica se curtida existe
                //caso não exista retorna NotFound
                if (curtid == null)
                    return NotFound();

                //caso exista remove a categoria
                curtidaRepository.Deletar(id);
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

