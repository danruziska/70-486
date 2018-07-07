using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirstExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string continua = "S";

            while (continua == "S")
            {
                Console.WriteLine("O que deseja fazer?");
                Console.WriteLine("1 - Criar novo blog");
                Console.WriteLine("2 - Criar novo Post");
                Console.WriteLine("3 - Ver todos os blogs");
                Console.WriteLine("4 - Ver todos os posts de um blog");
                Console.WriteLine("5 - Ver um post específico");

                using (var db = new BloggingContext())
                {
                    int opcao = int.Parse(Console.ReadLine());
                    if (opcao == 1)
                    {
                        Console.WriteLine("Insira o nome do novo blog:");
                        var blogName = Console.ReadLine();

                        var blog = new Blog { Name = blogName };
                        db.Blogs.Add(blog);
                        db.SaveChanges();
                        Console.WriteLine("Blog inserido com sucesso");
                    }
                    else if (opcao == 2)
                    {
                        Console.WriteLine("Para qual blog deseja criar o post?");

                        var query = from b in db.Blogs
                                    orderby b.BlogId
                                    select b;

                        foreach (var item in query)
                        {
                            Console.WriteLine("{0} - {1}", item.BlogId, item.Name);
                        }

                        int blogId = int.Parse(Console.ReadLine());

                        Console.WriteLine("Insira o título do post: ");
                        string titulo = Console.ReadLine();
                        Console.WriteLine("Insira o conteúdo do post: ");
                        string conteudo = Console.ReadLine();

                        var post = new Post()
                        {
                            BlogId = blogId,
                            Title = titulo,
                            Content = conteudo
                        };

                        db.Posts.Add(post);
                        db.SaveChanges();
                        Console.WriteLine("Post incluído com sucesso!");
                    }
                    else if (opcao == 3)
                    {
                        var query = from b in db.Blogs
                                    orderby b.BlogId
                                    select b;

                        foreach (var item in query)
                        {
                            Console.WriteLine("{0} - {1}", item.BlogId, item.Name);
                        }
                    }
                    else if (opcao == 4)
                    {
                        Console.WriteLine("Para qual o blog que deseja ver os posts?");
                        int blogId = int.Parse(Console.ReadLine());

                        var query = from p in db.Posts
                                    where p.BlogId == blogId
                                    orderby p.PostId
                                    select p;

                        foreach (var post in query)
                        {
                            Console.WriteLine("{0} - {1}", post.PostId, post.Title);
                        }
                    }
                    else if (opcao == 5)
                    {
                        Console.WriteLine("Selecione o post que deseja ver: ");

                        var query = from p in db.Posts
                                    orderby p.PostId
                                    select p;

                        foreach (var post in query)
                        {
                            Console.WriteLine("{0} - {1}", post.PostId, post.Title);
                        }

                        int postId = int.Parse(Console.ReadLine());

                        var query2 = query.Where(p => p.PostId == postId).FirstOrDefault();

                        Console.WriteLine(query2.Title);
                        Console.WriteLine(query2.Content);
                    }
                }

                Console.WriteLine("Deseja continuar?");
                continua = Console.ReadLine();
            }
        }
    }
}
