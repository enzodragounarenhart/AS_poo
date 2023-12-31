using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AS_poo.Domain.Entities
{
    public class Autor : Entity
    {
        public string nome { get; set; }
        public string cpf { get; set; }
        public string endereco { get; set; }
        public string contato { get; set; }
        public virtual ICollection<Livro> Livros { get; set;}  = new List<Livro>();
    }
}