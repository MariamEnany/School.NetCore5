using Microsoft.EntityFrameworkCore;
using SchoolDemo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SchoolDemo.Repo
{
    public class Repo<T> : IRepo<T> where T : class
    {

        protected readonly SchoolDemoDbContext context;
        public Repo(SchoolDemoDbContext context)
        {
            this.context = context;
        }

        public void Add(T entity)
        {
            context.Set<T>().Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            context.Set<T>().AddRange(entities);
        }

        public void Delete(T entity)
        {
            context.Set<T>().Remove(entity);
        }

        public IEnumerable<T> FindAll()
        {
            return context.Set<T>().ToList();
        }

        public IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return context.Set<T>().Where(expression);
        }

        public T Get(Guid Id)
        {
            return context.Set<T>().Find(Id);
        }

        public IEnumerable<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        public void Update(T entity)
        {
            context.Set<T>().Update(entity);
        }
    }
}
