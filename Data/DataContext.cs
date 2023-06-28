using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using AS_poo.Domain.Entities;

namespace AS_poo.Data
{
    public class DataContext : DbContext
    {
        public string DbPath {get;}

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            

        }
        public DbSet<Usuario> Usuario { get; set;}
        public DbSet<Autor> Autor { get; set;}
        public DbSet<Livro> Livro { get; set;}
    }
}