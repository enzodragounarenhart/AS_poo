using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AS_poo.Domain.Entities
{
    public class Usuario : Entity
    {
        public int idUsuario { get; set; }
        public string nome { get; set; }
        public string cpf { get; set; }
        public string endereco { get; set; }
        public string contato { get; set; }
        public virtual ICollection<Livro> LivrosEmprestados { get;}
    }
}