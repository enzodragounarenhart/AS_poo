using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AS_poo.Domain.Interfaces;
using AS_poo.Domain.Entities;

namespace AS_poo.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DataContext context;

        public UsuarioRepository(DataContext context)
        {
            this.context = context;
        }

        public Usuario GetById(int entityId)
        {
            return context.Usuario.SingleOrDefault(x=>x.Id ==entityId);
        }

        public IList<Usuario> GetAll()
        {
            return context.Usuario.ToList();
        }

        public void Save(Usuario entity)
        {
            context.Add(entity);
            context.SaveChanges();
        }

        public void Update(Usuario entity)
        {
            context.Usuario.Update(entity);
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