using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AS_poo.Domain.Entities
{
    public class Usuario
    {
        public int idUsuario { get; private set; }
        public string nome { get; set; }
        public string cpf { get; set; }
        public string endereco { get; set; }
        public string contato { get; set; }
        
        

        
        
        
        
    }
}