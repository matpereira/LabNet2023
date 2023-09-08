using System.Collections.Generic;
namespace Lab.EF.Logic
{
    public interface ILogic<TEntity,TDTO>
    {
        List<TDTO> GetAll();
        void Add(TDTO entity);
        void Update(TDTO entity);

    }
}
