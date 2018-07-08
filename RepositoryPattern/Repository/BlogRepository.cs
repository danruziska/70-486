using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.Repository
{
    public class BlogRepository : Repository<Blog, int>, IBlogRepository
    {
        public BlogRepository(BlogModel context) : base(context)
        {
        }

        public IEnumerable<Blog> GetTopBlogs(int count)
        {
            return BlogContext.Blogs.OrderByDescending(b => b.BlogId).Take(count).ToList();
        }

        public BlogModel BlogContext
        {
            get { return Context as BlogModel; }
        }
    }
}
