using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using API.Enums;

namespace API.Entidades
{
    public class Voo
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Partida é obrigatório")]        
        public DateTime Partida { get; set; }

        [Required(ErrorMessage = "Campo Chegada é obrigatório")]        
        public DateTime Chegada { get; set; }        

        [Required(ErrorMessage = "Campo Classe é obrigatório")]        
        public VooClasse VooClasse { get; set; }

        [Required(ErrorMessage = "Campo Quantidade de Ascentos é obrigatório")]        
        public int QuantidadeAcentos { get; set; }

        [Required(ErrorMessage = "Campo Valor é obrigatório")]        
        public float Valor { get; set; }

        [Required(ErrorMessage = "Campo Aeroporto é obrigatório")]        
        public int AeroportoId { get; set; }
        public Aeroporto Aeroporto { get; set; }
    }
}