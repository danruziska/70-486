using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryPattern.Repository;

namespace RepositoryPattern.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BlogModel _context;

        public UnitOfWork(BlogModel context)
        {
            _context = context;
            Blogs = new BlogRepository(_context);
        }

        public IBlogRepository Blogs { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
