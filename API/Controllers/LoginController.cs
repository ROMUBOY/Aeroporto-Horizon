using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{    
    public class LoginController : BaseController
    {
        public LoginController(DataContext context) : base (context)
        {            
        }

        [HttpPost]
        public async Task<ActionResult<Usuario>> Login(LoginDto loginDto)
        {
            var usuario = await _context.Usuarios.SingleOrDefaultAsync(x =>
            x.Email == loginDto.Email);

            if(usuario == null) return Unauthorized("Email ou senha incorreto.");

            if(usuario.Senha != loginDto.Senha)
            {
                return Unauthorized("Email ou senha incorreto.");
            }

            return usuario;
        }
    }
}