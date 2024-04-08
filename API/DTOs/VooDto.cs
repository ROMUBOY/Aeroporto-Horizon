using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class VooDto
    {
        public int Id { get; set; }

        public DateTime Partida { get; set; }   

        public DateTime Chegada { get; set; }   

        public string VooClasse { get; set; }
        
        public int QuantidadeAcentos { get; set; }
        
        public float Valor { get; set; }

        public string CidadePartida { get; set; }     

        public string CidadeDestino { get; set; }    
    }
}