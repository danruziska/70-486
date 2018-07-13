using ModelApproaches.InputModel;
using ModelApproaches.Models;
using ModelApproaches.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModelApproaches.Controllers
{
    public class PostController : Controller
    {
        // GET: Post
        public ActionResult Index()
        {
            /* 
             Exemplo de modelo de viewmodel       
             Nessa abordagem, a model representa um objeto intermediário entre a model e a view, normalmente esse objeto
             é utilizado quando há mais de uma entity que deve ser retornada, então a ViewModel encapsula essas entities
             (no caso, blog e post)
            */
            BlogModel bm = new BlogModel();
            BlogViewModel bvm = new BlogViewModel();
            bvm.Blogs = bm.GetBlogs();
            bvm.Posts = bm.GetPosts();
            return View(bvm);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }

        //Neste cenário é usado o DefaultBinding, que mapeia as propriedades pelo nome, caso sejam iguais
        [HttpPost]
        public string Create([Bind(Include="Title,Content")]PostInputModel postToCreate)
        {
            /* 
             Exemplo de modelo de input model       
             Nessa abordagem, foi criada uma classe especificamente para receber o input do usuário no cadastro. Poderia utilizar
             a entidade Post já existente, mas foi criada uma nova para deixar explícito que essa é uma classe de input model
            */
            string title = postToCreate.Title;
            string content = postToCreate.Content;
            return "OK";
        }
    }
}