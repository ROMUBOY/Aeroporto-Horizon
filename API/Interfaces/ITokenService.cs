using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entidades;

namespace API.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(Usuario usuario);
    }
}