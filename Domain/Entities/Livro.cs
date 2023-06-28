using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace AS_poo.Domain.Entities
{
    public class Livro : Entity
    {
        public int idLivro { get; set; }
        public string nome { get; set; }
        public int paginas { get; set; }
        public string genero { get; set; }
        public bool emprestado { get; set; }
        public int ano { get; set;}
        public virtual ICollection<Autor> Autores { get; set;}
        public int UsuarioId { get; set;}
        public Usuario Usuario { get; set;}
    }
}