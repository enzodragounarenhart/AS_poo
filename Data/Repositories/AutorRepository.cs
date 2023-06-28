using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AS_poo.Domain.Interfaces;
using AS_poo.Domain.Entities;

namespace AS_poo.Data.Repositories
{
    public class AutorRepository : IAutorRepository
    {
        private readonly DataContext context;

        public AutorRepository(DataContext context)
        {
            this.context = context;
        }

        public Autor GetById(int entityId)
        {
            return context.Autor.SingleOrDefault(x=>x.Id ==entityId);
        }

        public IList<Autor> GetAll()
        {
            return context.Autor.ToList();
        }

        public void Save(Autor entity)
        {
            context.Add(entity);
            context.SaveChanges();
        }

        public void Update(Autor entity)
        {
            context.Autor.Update(entity);
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