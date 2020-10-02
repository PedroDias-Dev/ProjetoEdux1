using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EduX.Domains;
using EduX.Interfaces;
using EduX.Repositories;
using Microsoft.AspNetCore.Authorization;
//using EduX.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EduX.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfilController : ControllerBase
    {
        private readonly IPerfilRepository perfilRepository;

        public PerfilController()
        {
            perfilRepository = new PerfilRepository();
        }



        /// <summary>
        /// Mostra todos os perfis cadastrados
        /// </summary>
        /// <returns>Lista com todos os perfis</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                //lista de perfis
                var perfils = perfilRepository.Listar();

                //verifica se existe no conxtexto atual
                //caso nao exista ele retorna NoContext
                if (perfils.Count == 0)
                    return NoContent();

                //caso exista retorno Ok e o total de perfis cadastradas
                return Ok(new
                {
                    totalCount = perfils.Count,
                    data = perfils
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // GET api/<PerfilController>/5
        /// <summary>
        /// Mostra um único perfil
        /// </summary>
        /// <param name="id">ID de perfil</param>
        /// <returns>Um perfil</returns>
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                //busca um perfil por id
                Perfil perfil = perfilRepository.BuscarPorId(id);

                //faz a verificacao no contexto para ver se o perfil foi encontrado
                //caso nao for encontrado o sistema retornara NotFound 
                if (perfil == null)
                    return NotFound();

                //se existir retorno vai passar o Ok e os dados do perfil 
                return Ok(perfil);
            }
            catch (Exception ex)
            {
                //caso ocorra algum erro retorno BadRequest e a mensagem da exception
                return BadRequest(ex.Message);
            }
        }



        // POST api/<PerfilController>
        /// <summary>
        /// Cadastra um novo perfil
        /// </summary>
        /// <param name="perfil">Objeto completo de perfil</param>
        /// <returns>Perfil cadastrado</returns>
        [HttpPost]
        public IActionResult Post(Perfil perfil)
        {
            try
            {
                //adiciona um novo perfil
                perfilRepository.Adicionar(perfil);

                //retorna Ok se o perfil tiver sido cadastrado
                return Ok(perfil);
            }
            catch (Exception ex)
            {
                //caso ocorra algum erro retorno BadRequest e a mensagem da exception
                return BadRequest(ex.Message);
            }
        }



        // PUT api/<PerfilController>/5
        /// <summary>
        /// Altera determinado perfil
        /// </summary>
        /// <param name="id">ID de perfil</param>
        /// <param name="perfil">Objeto perfil com as alterações</param>
        /// <returns>Info do perfil alterado</returns>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromForm] Perfil perfil)
        {
            try
            {
                //edita perfil
                perfilRepository.Editar(perfil);

                //retorna o Ok com os dados do perfil
                return Ok(perfil);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // DELETE api/<PerfilController>/5
        /// <summary>
        /// Exclui um perfil
        /// </summary>
        /// <param name="id">ID do perfil</param>
        /// <returns>ID excluído</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                //busca perfil pelo Id
                var perfil = perfilRepository.BuscarPorId(id);

                //verifica se perfil existe
                //caso não exista retorna NotFound
                if (perfil == null)
                    return NotFound();

                //caso exista remove o perfil
                perfilRepository.Remover(id);
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
