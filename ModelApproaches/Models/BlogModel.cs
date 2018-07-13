using ModelApproaches.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ModelApproaches.Models
{
    public class BlogModel
    {
        private List<Blog> blogList;
        private List<Post> postList;

        public BlogModel()
        {
            blogList = new List<Blog>();
            for (int i = 0; i < 5; i++)
            {
                blogList.Add(new Blog() { Name = string.Format("Blog #{0}", i.ToString()) });
            }

            postList = new List<Post>();
            for (int i = 0; i < 5; i++)
            {
                postList.Add(new Post() { Title = string.Format("Post #{0}", i.ToString()) });
            }
        }

        public List<Blog> GetBlogs()
        {            
            return blogList;
        }

        public List<Post> GetPosts()
        {
            return postList;
        }
    }
}