using ModelApproaches.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ModelApproaches.ViewModel
{
    public class BlogViewModel
    {
        public List<Blog> Blogs { get; set; }
        public List<Post> Posts { get; set; }
    }
}