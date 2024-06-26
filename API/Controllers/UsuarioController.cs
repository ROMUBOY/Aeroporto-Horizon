using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Data;
using API.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : BaseController
    {
        public UsuarioController(DataContext context) : base (context)
        {            
        }

        // GET: api/Usuario
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> ListarUsuarios()
        {
            return await this._context.Usuarios.ToListAsync();
        }

        // GET: api/Usuario/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> RetornarUsuario(int id)
        {
            var usuario = await this._context.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }

        // PUT: api/Usuario/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> EditarUsuario(int id, Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return BadRequest("Ocorreu um erro no processo.");
            }

            if(ExisteEmail(usuario))
            {
                return BadRequest( "Já foi cadastrado um usuário com este E-mail.");
            }

            this._context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await this._context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
                {
                    return NotFound("Usuário não encontrado");
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Usuario
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {            
            if(ExisteEmail(usuario))
            {
                return BadRequest( "Já foi cadastrado um usuário com este E-mail.");
            }

            this._context.Usuarios.Add(usuario);
            await this._context.SaveChangesAsync();

            return CreatedAtAction("GetUsuario", new { id = usuario.Id }, usuario);
        }

        // DELETE: api/Usuario/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            this._context.Usuarios.Remove(usuario);
            await this._context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsuarioExists(int id)
        {
            return this._context.Usuarios.Any(e => e.Id == id);
        }

        private bool ExisteEmail(Usuario usuario)
        {
            return this._context.Usuarios.Any(u => u.Email == usuario.Email && u.Id != usuario.Id);
        }
    }
}
