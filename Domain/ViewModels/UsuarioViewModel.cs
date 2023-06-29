using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AS_poo.Domain.ViewModels
{
    public class UsuarioViewModel
    {
        public int Id { get; set; }
        public string nome { get; set; }
        public string cpf { get; set; }
        public string endereco { get; set; }
        public string contato { get; set; }
        public virtual ICollection<LivroViewModel> LivrosEmprestados { get;}
    }
}