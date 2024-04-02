using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Data;
using API.Entidades;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    [Authorize]
    public class AeroportoController : BaseController
    {

        public AeroportoController(DataContext context) : base (context)
        {            
        }

        // GET: api/Aeroporto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aeroporto>>> ListarAeroportos()
        {
            return await _context.Aeroportos.ToListAsync();
        }

        // GET: api/Aeroporto/busca
        [HttpGet("{busca}")]
        public async Task<ActionResult<IEnumerable<Aeroporto>>> ListarAeroportos(string? busca)
        {            
            if (String.IsNullOrEmpty(busca))
            {
                return await _context.Aeroportos.ToListAsync();
            }

            return await _context.Aeroportos
                                 .Where(
                                        a => a.Nome.Contains(busca) || 
                                        a.Iata.Contains(busca) || 
                                        a.Cidade.Contains(busca)
                                    )
                                 .ToListAsync();
        }

        // PUT: api/Aeroporto/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> EditarAeroporto(int id, Aeroporto aeroporto)
        {
            if (id != aeroporto.Id)
            {
                return BadRequest();
            }

            if(ExisteIata(aeroporto))
            {
                return Problem( 
                    title: "Iata já Cadastrado", 
                    detail: "Já foi cadastrado um aeroporto com este Iata." 
                );
            }

            if(ExisteCidade(aeroporto))
            {
                return Problem( 
                    title: "Cidade já Cadastrado", 
                    detail: "Já foi cadastrado um aeroporto para esta cidade." 
                );
            }

            _context.Entry(aeroporto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AeroportoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Aeroporto
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Aeroporto>> CriarAeroporto(Aeroporto aeroporto)
        {
            if(ExisteIata(aeroporto))
            {
                return Problem( 
                    title: "Iata já Cadastrado", 
                    detail: "Já foi cadastrado um aeroporto com este Iata." 
                );
            }

            if(ExisteCidade(aeroporto))
            {
                return Problem( 
                    title: "Cidade já Cadastrado", 
                    detail: "Já foi cadastrado um aeroporto para esta cidade." 
                );
            }

            _context.Aeroportos.Add(aeroporto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("ListarAeroportos", new { id = aeroporto.Id }, aeroporto);
        }

        // DELETE: api/Aeroporto/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarAeroporto(int id)
        {
            var aeroporto = await _context.Aeroportos.FindAsync(id);
            if (aeroporto == null)
            {
                return NotFound();
            }

            _context.Aeroportos.Remove(aeroporto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AeroportoExists(int id)
        {
            return _context.Aeroportos.Any(e => e.Id == id);
        }

        private bool ExisteIata(Aeroporto aeroporto)
        {
            return _context.Aeroportos.Any(a => a.Iata == aeroporto.Iata && a.Id != aeroporto.Id);
        }

        private bool ExisteCidade(Aeroporto aeroporto)
        {
            return _context.Aeroportos.Any(a => a.Cidade == aeroporto.Cidade && a.Id != aeroporto.Id);
        }
    }
}
