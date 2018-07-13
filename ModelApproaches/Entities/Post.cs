using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ModelApproaches.Entities
{
    public class Post
    {
        public int BlogId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}