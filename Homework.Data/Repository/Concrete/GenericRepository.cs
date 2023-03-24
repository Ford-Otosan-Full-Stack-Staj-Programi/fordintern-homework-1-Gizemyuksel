using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Data.Repository;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly AppDbContext context;
    private DbSet<T> entities;

    public GenericRepository(AppDbContext context)
    {
        this.context = context;
        this.entities = this.context.Set<T>();
    }
    public List<T> GetAll()
    {
        return entities.ToList();
    }

    public T GetById(int entityId)
    {
        return entities.Find(entityId);
    }

    public void Insert(T entity)
    {
        
        entities.Add(entity);
    }

    public void Remove(int id)
    {
            var entity = GetById(id);
       
            entities.Remove(entity);
        
    }

    

    public void Update(T entity)
    {
        entities.Update(entity);
    }
}

