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
using EduX.Utils;

namespace EduX.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DicaController : ControllerBase
    {
        private readonly IDicaRepository _dicaRepository;
        private readonly ICurtidaRepository curtidaRepository;

        public DicaController()
        {
            _dicaRepository = new DicaRepository();
            curtidaRepository = new CurtidaRepository();
        }

        // GET: api/Dica
        /// <summary>
        /// Mostra todas as dicas cadastradas
        /// </summary>
        /// <returns>Lista com todas as dicas</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var dica = _dicaRepository.Listar();
                //var curtidas = curtidaRepository.BuscarPorIdDica(dica.IdDica);

                foreach (var item in dica){
                    item.Curtida = curtidaRepository.BuscarPorIdDica(item.IdDica);
                    //item.Curtida = curtidas.Count;
                }

                if (dica.Count == 0)
                    return NoContent();

                return Ok(new
                {
                    data = dica,
                    //totalCount = curtidas
                });

            }
            catch (Exception)
            {
                //caso ocorra algum erro retorna mensagem de erro 
                return BadRequest(new
                {
                    stausCode = 400,
                    error = "Ocorreu um erro no endpoint Get/dicas, envie um email para email@gmail.com informando"
                });
            }
        }


        // GET: api/Dica/5
        /// <summary>
        /// Mostra uma única dica
        /// </summary>
        /// <param name="id">ID da dica</param>
        /// <returns>Uma dica</returns>
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                var dica = _dicaRepository.BuscarPorId(id);
                var curtidas = curtidaRepository.BuscarPorIdDica(id);

                if (dica == null)
                    return NotFound();

                return Ok(new
                {
                    data = dica,
                    totalCount = curtidas.Count
                });
            }
            catch (Exception ex)
            {
                //caso ocorra algum erro retorna mensagem de erro 
                return BadRequest(ex.Message);
            }
        }



        // PUT: api/Dica/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        /// <summary>
        /// Altera determinada dica
        /// </summary>
        /// <param name="id">ID de dica</param>
        /// <param name="dica">Objeto dica com as alterações</param>
        /// <returns>Info da dica alterada</returns>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id,[FromForm] Dica dica)
        {
            try
            {
                var instituicaoTemp = _dicaRepository.BuscarPorId(id);

                if (instituicaoTemp == null)
                    return NotFound();

                dica.IdDica = id;
                _dicaRepository.Alterar(dica);

                return Ok(dica);
            }
            catch (Exception ex)
            {
                //caso ocorra algum erro retorna mensagem de erro 
                return BadRequest(ex.Message);
            }
        }





        // POST: api/Dica
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        /// <summary>
        /// Cadastra uma nova dica
        /// </summary>
        /// <param name="dica">Objeto completo de dica</param>
        /// <returns>Dica cadastrada</returns>
        [HttpPost]
        public IActionResult Post(Dica dica)
        {
            try
            {
                //verifico se foi enviado um arquivo com a imagem
                if (dica.Imagem != null)
                {
                    var urlImagem = Upload.Local(dica.Imagem);

                    dica.UrlImagem = urlImagem; 
                }

                _dicaRepository.Cadastrar(dica);

                return Ok(dica);
            }
            catch (Exception ex)
            {
                //caso ocorra algum erro retorna mensagem de erro 
                return BadRequest(ex.Message);
            }
        }



        // DELETE: api/Dica/5
        /// <summary>
        /// Exclui uma dica
        /// </summary>
        /// <param name="id">ID de dica</param>
        /// <returns>ID excluído</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _dicaRepository.Deletar(id);
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
