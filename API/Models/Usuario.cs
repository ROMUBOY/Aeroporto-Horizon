using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace API.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Nome é obrigatório")]        
        [MaxLength(150)]
        public string Nome { get; set; }        
        
        [Required(ErrorMessage = "Campo E-mail é obrigatório")]        
        [MaxLength(150)]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "O e-mail não é válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo Senha é obrigatório")]        
        [MaxLength(150)]
        public string Senha { get; set; }
    }
}