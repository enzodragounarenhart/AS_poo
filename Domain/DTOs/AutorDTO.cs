using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AS_poo.Domain.DTOs
{
    public class AutorDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Endereco { get; set; }
        public string Contato { get; set; }
        
        public ICollection<LivroDTO> Livros { get; set; }  = new List<LivroDTO>();
    }
}