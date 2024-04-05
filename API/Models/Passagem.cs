using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace API.Models
{
    public class Passagem
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Nome é obrigatório")]        
        [MaxLength(150)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo CPF é obrigatório")]        
        [MaxLength(11)]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Campo Data de Nascimento é obrigatório")]        
        public DateTime DataNascimento { get; set; }
        
        [Required(ErrorMessage = "Campo E-mail é obrigatório")]        
        [MaxLength(150)]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "O e-mail não é válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo Voo é obrigatório")]        
        public float Valor { get; set; }

        [Required(ErrorMessage = "Campo Voo é obrigatório")]        
        public int VooId { get; set; }
        public Voo? Voo { get; set; }

        public string? BagagemCodigo { get; set; }
    }
}