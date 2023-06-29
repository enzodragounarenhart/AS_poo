using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AS_poo.Domain.DTOs
{
    public class LivroDTO
{
    public int Id { get; set; }
    public int? UsuarioId { get; set; }
    public string Nome { get; set; }
    public int Paginas { get; set; }
    public string Genero { get; set; }
    public bool Emprestado { get; set; }
    public int Ano { get; set; }

    public ICollection<AutorDTO> Autores { get; set; }  = new List<AutorDTO>();
    public UsuarioDTO Usuario { get; set; }
}
}