using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repository
{
    public class GenericRepository<T> : IGenericDal<T> where T : class,new()
    {
        public void Delete(T t)
        {
            using var context = new AgricultureContext();
            context.Remove(t);
            context.SaveChanges();
        }

        public List<T> GetAll()
        {
            using var context = new AgricultureContext();
            return context.Set<T>().ToList();
        }

        public T GetById(int Id)
        {
            using var context= new AgricultureContext();
            return context.Set<T>().Find(Id);
        }

        public void Insert(T t)
        {
            using var context = new AgricultureContext();
            context.Add(t);
            context.SaveChanges();
        }

        public void Update(T t)
        {
            using var context = new AgricultureContext();
            context.Update(t);
            context.SaveChanges();
        }
    }
}
