using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BaseRepository<T> where T : class 
    {
        public virtual List<T> List()
        {
            var ctx = new NewsEntities();
            return ctx.Set<T>().ToList();
        }

        public virtual void Add(T entity)
        {
            var crx = new NewsEntities();
            crx.Set<T>().Add(entity);
            crx.SaveChanges();
        }

        public virtual void Update(T entity)
        {
            var crx = new NewsEntities();
            crx.Set<T>().Attach(entity);
            crx.Entry(entity).State = EntityState.Modified;
            crx.SaveChanges();
        }

        public virtual void Remove(int entityId)
        {
            var crx = new NewsEntities();
            T Entity = crx.Set<T>().Find(entityId);

            crx.SaveChanges();
            if (crx.Entry(Entity).State == EntityState.Detached)
            {
                crx.Set<T>().Attach(Entity);
            }
            crx.Set<T>().Remove(Entity);
            crx.SaveChanges();
        }

        public virtual T FindById(int EntityId)
        {
            var crx = new NewsEntities();
            return crx.Set<T>().Find(EntityId);
        }
    }
}
