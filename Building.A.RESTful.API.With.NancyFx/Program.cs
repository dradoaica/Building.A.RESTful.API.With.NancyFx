using Microsoft.Owin.Hosting;
using Owin;
using System;

namespace Building.A.RESTful.API.With.NancyFx
{
    class Program
    {
        public class Startup
        {
            public void Configuration(IAppBuilder app)
            {
                app.UseNancy();
            }
        }

        private static void PopulateRepositories()
        {
            PersonRepository.Instance.Add(new Person { Id = 1, FirstName = "Danut", LastName = "Radoaica" });
            UserRepository.Instance.Add(new User { UserName = "dradoaica", Password = "1234", Identifier = Guid.NewGuid() });
        }

        static void Main(string[] args)
        {
            var url = "http://+:8080";

            using (WebApp.Start<Startup>(url))
            {
                Console.WriteLine("Running on {0}", url);

                PopulateRepositories();

                Console.WriteLine("Press enter to exit");
                Console.ReadLine();
            }
        }
    }
}
