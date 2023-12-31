using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AS_poo.Domain.DTOs
{
    public class UsuarioDTO
{
    public int Id { get; set; }
    
    public string Nome { get; set; }
    public string CPF { get; set; }
    public string Endereco { get; set; }
    public string Contato { get; set; }

    public List<LivroDTO> LivrosEmprestados { get; set; }  = new List<LivroDTO>();
}
}