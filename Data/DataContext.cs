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

        public DataContext()
        {
            var path = Directory.GetCurrentDirectory();
            DbPath = System.IO.Path.Join(path, "as_db.db");

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
            => optionsBuilder.UseSqlite($"Data Source ={DbPath}");

        public DbSet<Usuario> Usuario { get; set;}
        public DbSet<Autor> Autor { get; set;}
        public DbSet<Livro> Livro { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}