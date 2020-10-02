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
    public class UsuarioController : ControllerBase
    {

        private readonly IUsuarioRepository _userRepository;
        public UsuarioController()
        {
            _userRepository = new UsuarioRepository();
        }

        // GET: api/Usuario
        /// <summary>
        /// Mostra todos os usuários cadastrados
        /// </summary>
        /// <returns>Lista com todos os usuários</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> Get()  
        {
            try
            {
                var usuarios = _userRepository.Listar();

                //Verifica se tem usuarios
                if (usuarios.Count == 0)
                    return NoContent();

                //Caso exista retorna OK
                return Ok(new
                {
                    totalCount = usuarios.Count,
                    data = usuarios
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    statusCode = 400,
                    error = "Ocorreu um erro ao obter os usuarios, revise seu request ou envie um e-mail para email@email.com informando [400 Code]"
                });
            }
        }






        // GET: api/Usuario/5
        /// <summary>
        /// Mostra um único usuário
        /// </summary>
        /// <param name="id">ID de usuário</param>
        /// <returns>Um usuário</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> Get(Guid id)
        {
            try
            {
                //Busco o produto pelo Id
                Usuario usuario = _userRepository.BuscarPorId(id);

                //Verifico se o usuario foi encontrado
                //Caso não exista retorno NotFounf
                if (usuario == null)
                    return NotFound();

                //Caso exista retorno Ok e os dados do usuario
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                //Caso ocorra algum erro retorno BadRequest e a mensagem da exception
                return BadRequest(ex.Message);
            }
        }






        // PUT: api/Usuario/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        /// <summary>
        /// Altera determinado usuário
        /// </summary>
        /// <param name="id">ID do usuário</param>
        /// <param name="usuario">Objeto usuário  com suas alterações</param>
        /// <returns>Info do usuário alterado</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, Usuario usuario)
        {
            try
            {
                //Edita o usuario
                _userRepository.Editar(usuario);

                //Retorna Ok com os dados do usuario 
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Usuario
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        /// <summary>
        /// Cadastra um novo usuário
        /// </summary>
        /// <param name="usuario">Objeto completo de usuário</param>
        /// <returns>Usuário cadastrado</returns>
        [HttpPost]
        public IActionResult Post([FromBody]Usuario usuario)
        {
            try
            {
                usuario.Senha = Crypto.Criptografar(usuario.Senha, usuario.Email.Substring(0, 4));
                //Adiciona um novo usuario
                _userRepository.Adicionar(usuario);


                //Retorna Ok caso o usuario tenha sido cadastrado
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }







        // DELETE: api/Usuario/5
        /// <summary>
        /// Exclui um usuário
        /// </summary>
        /// <param name="id">ID do usuário</param>
        /// <returns>ID excluído</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Usuario>> Delete(Guid id)
        {
            try
            {
                //Busca o usuario pelo Id
                var usuario = _userRepository.BuscarPorId(id);

                //Verifica se o usuario existe
                //Caso não exista retorna NotFound
                if (usuario == null)
                    return NotFound();

                //Caso exista remove o usuario
                _userRepository.Remover(id);
                //Retorna Ok
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //private bool UsuarioExists(Guid id)
        //{
            //return _context.Usuario.Any(e => e.IdUsuario == id);
        //}
    }
}
