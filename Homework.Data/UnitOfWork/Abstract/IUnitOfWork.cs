using Homework.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Data.UnitOfWork;

public interface IUnitOfWork : IDisposable
{

    IGenericRepository<Staff> StaffRepository { get; }

    void Complete();


}