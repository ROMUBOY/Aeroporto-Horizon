using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Data;
using API.Entidades;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VooController : BaseController
    {
        public VooController(DataContext context) : base (context)
        {            
        }

        // GET: api/Voo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Voo>>> ListarVoos()
        {
            DateTime dataAtual = DateTime.Now;
            return await _context.Voos.Where(v => v.Partida > dataAtual).ToListAsync();
        }


        [HttpGet("Disponiveis")]
        public async Task<ActionResult<IEnumerable<Voo>>> ListarVoosDisponiveis()
        {
            DateTime dataAtual = DateTime.Now;
            return await _context.Voos.Where(v => v.QuantidadeAcentos > 0 && v.Partida > dataAtual).ToListAsync();
        }

        // GET: api/Voo/Passageiros/5
        [HttpGet("Passageiros/{id}")]
        public async Task<ActionResult<IEnumerable<string>>> ListarVooPassageiros(int id)
        {
            return await _context.Passagens.Where(P => P.VooId == id).Select(p => p.Nome).ToListAsync();
        }

        // GET: api/Voo/valor
        [HttpGet("Filtros")]
        public async Task<ActionResult<IEnumerable<Voo>>> ListarVoos(DateTime partida, DateTime chegada,int aeroportoId,float valor = 0f)
        {
            return await _context.Voos.Where(
                                        v => v.Partida == partida &&
                                        v.Chegada == partida && 
                                        (v.AeroportoId == aeroportoId || aeroportoId == 0) &&
                                        v.QuantidadeAcentos > 0 &&
                                        (v.Valor < valor || valor == 0f)
                                    ).ToListAsync();
        }

        // PUT: api/Voo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> EditarVoo(int id, Voo voo)
        {
            if (id != voo.Id)
            {
                return BadRequest();
            }

            if(!DatasValidas(voo))
            {                
                return BadRequest("Data e hora de partida devem ser anteriores a data e hora de chegada.");
            }

            if(voo.QuantidadeAcentos <= 0)            
            {                
                return BadRequest("Quantidade de acentos no voo não pode ser 0.");
            }

            if(voo.Valor <= 0f)            
            {                
                return BadRequest("Valor do voo não pode ser 0.");
            }
                        
            _context.Entry(voo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VooExists(id))
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

        // POST: api/Voo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Voo>> CriarVoo(Voo voo)
        {            
            if(!DatasValidas(voo))
            {                
                return BadRequest("Data e hora de partida devem ser anteriores a data e hora de chegada.");
            }

            if(voo.QuantidadeAcentos <= 0)            
            {                
                return BadRequest("Quantidade de acentos no voo não pode ser 0.");
            }

            if(voo.Valor <= 0f)            
            {                
                return BadRequest("Valor do voo não pode ser 0.");
            }

            _context.Voos.Add(voo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("ListarVoos", new { id = voo.Id }, voo);
        }

        // DELETE: api/Voo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarVoo(int id)
        {
            var voo = await _context.Voos.FindAsync(id);
            if (voo == null)
            {
                return NotFound();
            }

            _context.Voos.Remove(voo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VooExists(int id)
        {
            return _context.Voos.Any(e => e.Id == id);
        }

        private bool DatasValidas (Voo voo)
        {
            return DateTime.Compare(voo.Partida, voo.Chegada) < 0;
        }
    }
}
