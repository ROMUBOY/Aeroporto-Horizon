using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace API.Models
{
    public class Aeroporto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Cidade é obrigatório")]
        [MaxLength(200)]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Campo Nome é obrigatório")]
        [MaxLength(200)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Código IATA é obrigatório")]
        [MaxLength(200)]
        public string Iata { get; set; }
    }
}