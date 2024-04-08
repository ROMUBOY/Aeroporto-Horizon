using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class VoucherDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime Partida { get; set; }
        public DateTime Chegada { get; set; }  
        public string CidadePartida { get; set; }
        public string CidadeDestino { get; set; }
    }
}