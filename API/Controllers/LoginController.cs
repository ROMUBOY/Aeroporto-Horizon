using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Models;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{    
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly ITokenService _tokenService;
        public LoginController(DataContext context, ITokenService tokenService) 
        {           
            this._tokenService = tokenService; 
            this._context = context;
            
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioDto>> Login(LoginDto loginDto)
        {
            var usuario = await this._context.Usuarios.SingleOrDefaultAsync(x =>
            x.Email == loginDto.Email);

            if(usuario == null) return Unauthorized("Email ou senha incorreto.");

            if(usuario.Senha != loginDto.Senha)
            {
                return Unauthorized("Email ou senha incorreto.");
            }

            return new UsuarioDto
            {
                Email = usuario.Email,
                Token = _tokenService.CreateToken(usuario)
            };
        }
    }
}