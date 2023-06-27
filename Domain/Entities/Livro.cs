using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace AS_poo.Domain.Entities
{
    public class Livro
    {
        [Key]
        public int idLivro { get; private set; }
        public string nome { get; set; }
        public int paginas { get; set; }
        public string genero { get; set; }
        public bool emprestado { get; set; }    
    }
}