using ResultPlusPlus.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ResultPlusPlus.Data_Access
{
    public class SQLRepository<T> : IRepository<T> where T:class
    {
        internal DataContext context;
        internal DbSet<T> dbset;
        public SQLRepository(DataContext context)
        {
            this.context = context;
            this.dbset = context.Set<T>();
        }

        public IQueryable<T> Collection()
        {
            return dbset;
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        public void Delete(int Id)
        {
            var t = Find(Id);
            //Check if an item can remove or not
            if (context.Entry(t).State == EntityState.Modified)
                dbset.Attach(t);
            dbset.Remove(t);
        }

        public void Edit(T t)
        {
            dbset.Attach(t);
            context.Entry(t).State = EntityState.Modified;
        }

        public T Find(int Id)
        {
            T t = dbset.Find(Id);
            return t;
        }

        public void Insert(T t)
        {
            dbset.Add(t);
        }
    }
}