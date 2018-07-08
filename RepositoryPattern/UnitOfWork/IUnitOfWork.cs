using RepositoryPattern.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IBlogRepository Blogs { get; }
        int Complete();
    }
}
