using System.Collections.Generic;

namespace ArtiLib.Interfaces
{
    public interface ICommonService<T>
    {
        int Add(T entity);

        void RemoveById(int id);

        IEnumerable<T> GetAll();

        T GetById(int id);

        void Edit(T entity);
    }
}