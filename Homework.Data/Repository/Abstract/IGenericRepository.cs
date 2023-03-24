using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Data.Repository;

public interface IGenericRepository<T> where T : class
{
    T GetById(int entityId);
    void Insert(T entity);
    
    void Remove(int id);
    void Update(T entity);
    List<T> GetAll();
}