
using System.Collections.Generic;

namespace Lab.EF.Logic
{
    public interface ILogic<T>
    {
        List<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
        int Find(int id);
    }

}
