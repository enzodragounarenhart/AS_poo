using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AS_poo.Domain.ViewModels
{
    public class AutorLivroViewModel
    {
        public int AutorId { get; set; }
        public int LivroId { get; set; }
        public AutorViewModel Autor { get; set; }
        public LivroViewModel Livro { get; set; }
        public DateOnly dataAutorado { get; set;}
    }
}