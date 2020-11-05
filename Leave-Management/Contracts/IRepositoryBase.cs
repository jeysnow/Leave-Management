using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leave_Management.Contracts
{
    public interface IRepositoryBase<T> where T: class
    {
        ICollection<T> Findall();
        T FindById(int id);
        bool Create(T entity);
        bool Update(T entity);
        bool Delete(T entity);
        bool Save();

        bool IsExists(int id);
    }
}
