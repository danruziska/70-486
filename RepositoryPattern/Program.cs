using RepositoryPattern.Repository;
using RepositoryPattern.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            //IUnitOfWork uow = new UnitOfWork.UnitOfWork(new BlogModel());
            IUnitOfWork uow = new MockBlogUnitOfWork();
            var results = uow.Blogs.GetTopBlogs(7);

            foreach (var item in results)
            {
                Console.WriteLine(item.Name);
            }
        }
    }

    class MockBlogUnitOfWork : IUnitOfWork
    {
        public MockBlogUnitOfWork()
        {
            Blogs = new MockBlogRepository(null);
        }

        public IBlogRepository Blogs
        {
            get; private set;
        }

        public int Complete()
        {
            return 1;
        }

        public void Dispose()
        {            
        }
    }

    public class MockBlogRepository : Repository<Blog, int>, IBlogRepository
    {
        public MockBlogRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<Blog> GetTopBlogs(int count)
        {
            List<Blog> blogList = new List<Blog>();

            for (int i = 1; i <= count; i++)
            {
                blogList.Add(new Blog() { BlogId = i, Name = string.Format("Blog #{0}", i) });
            }

            return blogList;
        }
    }
}
