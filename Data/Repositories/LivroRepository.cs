using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AS_poo.Domain.Interfaces;
using AS_poo.Domain.Entities;

namespace AS_poo.Data.Repositories
{
    public class LivroRepository : ILivroRepository
    {
        private readonly DataContext context;

        public LivroRepository(DataContext context)
        {
            this.context = context;
        }

        public Livro GetById(int entityId)
        {
            return context.Livro.SingleOrDefault(x=>x.Id ==entityId);
        }

        public IList<Livro> GetAll()
        {
            return context.Livro.ToList();
        }

        public void Save(Livro entity)
        {
            context.Add(entity);
            context.SaveChanges();
        }

        public void Update(Livro entity)
        {
            context.Livro.Update(entity);
            context.SaveChanges();
        }

        public bool Delete(int entityId)
        {
            var entity = GetById(entityId);
            context.Remove(entity);
            context.SaveChanges();
            return true;
        }
    }
}