using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Data;
using API.Models;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{        
    [Authorize]
    public class PassagemController : BaseController
    {   
        public PassagemController(DataContext context) : base (context)
        {            
        }

        // GET: api/Passagem
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Passagem>>> ListarPassagens()
        {
            return await this._context.Passagens.ToListAsync();
        }

        // GET: api/Passagem/00000000000
        [HttpGet("Passageiro/{cpf}")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Passagem>>> ListarPassagensPassageiro(string cpf)
        {
            return await this._context.Passagens.Where(p => p.Cpf == cpf).ToListAsync();
        }

        // GET: api/Passagem/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Passagem>> RetornarPassagem(int id)
        {
            var passagem = await this._context.Passagens.FindAsync(id);

            if (passagem == null)
            {
                return NotFound();
            }

            return passagem;
        }

        // PUT: api/Passagem/5        
        [HttpPut("{id}")]
        public async Task<IActionResult> EditarPassagem(int id, Passagem passagem)
        {
            if (id != passagem.Id)
            {
                return BadRequest();
            }

            var voo = await _context.Voos.FindAsync(passagem.VooId);

            if(voo == null)
            {
                return BadRequest("Voo cancelado, desculpe-nos o transtorno.");
            }

            if(voo.QuantidadeAcentos == 0)
            {
                return BadRequest("Sem acento disponível, desculpe-nos o transtorno.");
            }

            _context.Entry(passagem).State = EntityState.Modified;

            try
            {
                await this._context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PassagemExists(id))
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

        // POST: api/Passagem        
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<Passagem>> CriarPassagem(Passagem passagem)
        {            
            var voo = await this._context.Voos.FindAsync(passagem.VooId);

            if(voo == null)
            {
                return BadRequest("Voo cancelado, desculpe-nos o transtorno.");
            }

            if(voo.QuantidadeAcentos == 0)
            {
                return BadRequest("Sem acento disponível, desculpe-nos o transtorno.");
            }

            voo.QuantidadeAcentos--;
            this._context.Entry(voo).State = EntityState.Modified;

            passagem.Valor = CalcularValorPassagem(passagem, voo);

            passagem.BagagemCodigo = GerarCodigoBagagem();

            this._context.Passagens.Add(passagem);
            await this._context.SaveChangesAsync();

            return CreatedAtAction("RetornarPassagem", new { id = passagem.Id }, passagem);
        }

        // DELETE: api/Passagem/5
        [HttpDelete("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> DeletaPassagem(int id)
        {
            var passagem = await _context.Passagens.FindAsync(id);
                        
            if (passagem == null)
            {
                return NotFound();
            }

            var voo = await _context.Voos.FindAsync(passagem.VooId);

            if(voo != null)
            {
                voo.QuantidadeAcentos++;                

                _context.Entry(voo).State = EntityState.Modified;
            }

            this._context.Passagens.Remove(passagem);
            await this._context.SaveChangesAsync();

            return NoContent();
        }

        private bool PassagemExists(int id)
        {
            return this._context.Passagens.Any(e => e.Id == id);
        }

        private float CalcularValorPassagem(Passagem passagem, Voo voo)
        {
            if(passagem.BagagemCodigo != null)
            {
                return passagem.Valor + passagem.Valor * 0.1f;
            }
            else
            {
                return passagem.Valor;
            }
        }

        private string GerarCodigoBagagem()
        {
            Random random = new Random();

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            StringBuilder codeBuilder = new StringBuilder(12);

            for (int i = 0; i < 12; i++)
            {
                codeBuilder.Append(chars[random.Next(12)]);
            }

            return codeBuilder.ToString();
        }
    }
}
