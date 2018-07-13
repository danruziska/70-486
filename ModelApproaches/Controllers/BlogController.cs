using ModelApproaches.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModelApproaches.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        public ActionResult Index()
        {            
            /* 
             Exemplo de modelo de domínio       
             Nessa abordagem, a model representa diretamente o dado que foi buscado (uma lista de objetos do tipo Blog)
            */
            BlogModel model = new BlogModel();
            var blogs = model.GetBlogs();
            
            return View(blogs);
        }
    }
}