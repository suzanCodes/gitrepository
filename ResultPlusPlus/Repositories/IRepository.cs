using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResultPlusPlus.Repositories
{
    public interface IRepository<T> where T:class
    {
       IQueryable<T> Collection();
        void Insert(T t);
        void Commit();
        void Delete(int Id);
        void Edit(T t);
        T Find(int Id);


    }
}