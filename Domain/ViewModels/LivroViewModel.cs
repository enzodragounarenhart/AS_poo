using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AS_poo.Domain.ViewModels
{
    public class LivroViewModel
    {
        public int Id { get; set; }
        public string nome { get; set; }
        public int paginas { get; set; }
        public string genero { get; set; }
        public bool emprestado { get; set; }
        public int ano { get; set;}
        public virtual ICollection<AutorViewModel> Autores { get; set;}
        public int? UsuarioId { get; set;}
        public UsuarioViewModel Usuario { get; set;}
    }
}