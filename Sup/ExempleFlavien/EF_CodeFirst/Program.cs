using Model;
namespace EF_CodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new QuizContext();
            var Links1 = new Links( "https://google.com");
            var Reponse1 = new Reponse("Ceci est la Reponse1", "Ceci est l'explication de la Reponse1");
            var Question1 = new Question( "Ceci est la Question1");
            var Links2 = new Links("https://facbook.com");
            var Links3 = new Links("https://apple.com");
            var ThemeEx1 = new ThemeEx("Ceci est le Theme1");
            Reponse1.Links.Add(Links1);
            Reponse1.Links.Add(Links2);
            Reponse1.Links.Add(Links3);
            Reponse1.isTrool = true;
            Links1.Reponse = Reponse1;
            Links2.Reponse = Reponse1;
            Links3.Reponse = Reponse1;

            Reponse1.Question=Question1;
            Question1.ThemeEx=ThemeEx1;
            Question1.Reponses.Add(Reponse1);
            ThemeEx1.Questions.Add(Question1);
            db.ThemeEx.Add(ThemeEx1);
            db.SaveChanges();
            Console.WriteLine("Theme doit être enregistré");
            Console.WriteLine("---------------------------");
            Console.WriteLine("Reading From Base:");
            var query = from b in db.Reponses
                        orderby b.Id
                        select b;
            foreach (var item in query)
            {
                Console.WriteLine(item.ReponseText);
                Console.WriteLine(item.ReponseExplication);
                Console.WriteLine(item.isTrool);
            }
            var query2 = from b in db.ThemeEx
                        orderby b.Id
                        select b;
            foreach (var item in query2)
            {
                Console.WriteLine(item.Id);
                Console.WriteLine(item.ThemeName);
            }
            Console.ReadLine();

            /* 
             var db= new MyContext();
             var post=new Post();
             var post1=new Post();
             var blog=new Blog();
             post.Title = "This is post";
             post.Content = "This is post Content";
             post1.Content = "This is post1 Content";
             post1.Title = "This is post1";
             blog.Url = "This is blog";
             blog.Posts.Add(post);
             blog.Posts.Add(post1);
             db.Blogs.Add(blog);
             db.SaveChanges();
             Console.WriteLine("Blogs enregistrés");
             Console.WriteLine("--------------------------------------");
             Console.WriteLine("Reading Blogs from base");

             var query = from b in db.Blogs
                         orderby b.BlogId
                         select b;
             foreach (var item in query)
             {
                 Console.WriteLine(item.Url);
                 Console.WriteLine(item.Posts);
             }
             Console.ReadLine();

             Console.WriteLine("--------------------------------------");
             Console.WriteLine("Reading Post from base");
             var query1 = from b in db.Posts
                         orderby b.PostId
                         select b;
             foreach (var item in query1)
             {
                 Console.WriteLine(item.Title);
                 Console.WriteLine(item.Content);
                 Console.WriteLine(item.Blog);
             }
             Console.ReadLine();
            */
        }
    }

}