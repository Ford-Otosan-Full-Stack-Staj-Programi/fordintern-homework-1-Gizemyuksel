using Homework.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Data.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext context;
    private bool disposed;

    public IGenericRepository<Staff> StaffRepository { get; private set; }

    public IGenericRepository<Staff> AccountRepository => throw new NotImplementedException();

    public UnitOfWork(AppDbContext context)
    {
        this.context = context;

        StaffRepository = new GenericRepository<Staff>(context);
        
    }

    public void CompleteWithTransaction()
    {
        using (var dbContextTransaction = context.Database.BeginTransaction())
        {
            try
            {
                context.SaveChanges();
                dbContextTransaction.Commit();
            }
            catch (Exception ex)
            {
                // logging                    
                dbContextTransaction.Rollback();
            }
        }
    }

    public void Complete()
    {
        context.SaveChanges();
    }

    protected virtual void Clean(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                context.Dispose();
            }
        }
        this.disposed = true;
    }

    public void Dispose()
    {
        Clean(true);
        GC.SuppressFinalize(this);
    }
}
