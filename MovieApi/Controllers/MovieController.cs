using DependencyManager;
using MovieDomain.Entities;
using MovieDomain.Manager;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Http;

namespace MovieApi.Controllers
{
    public class MovieController : ApiController
    {

        MovieManager manager;
        public MovieController()
        {
            var kernel = new StandardKernel();
            kernel.Load(new MovieModule());
            manager = kernel.Get<MovieManager>();
        }

        [HttpPost]
        public async Task<IHttpActionResult> AddMoviesAsync(IEnumerable<Movie> movies)
        {
            var result = new List<Movie>();

            int loops = (int)Math.Ceiling(movies.Count() / 4.0);

            for (int i = 0; i < loops; i++)
            {
                var selected = movies.Skip(i * 4).Take(4).ToList();
                Task<Movie>[] task = new Task<Movie>[selected.Count()];

                foreach (var movie in selected)
                {
                    task[selected.IndexOf(movie)] = new Task<Movie>(() => manager.RegisterNewMovie(movie));
                    task[selected.IndexOf(movie)].Start();
                }


                Task.WaitAll(task);
            }

            return Ok(result);

        }

        [HttpGet]
        public async Task<IHttpActionResult> ListAllMovies()
        {


            Task<IEnumerable<Movie>> t1 = new Task<IEnumerable<Movie>>(manager.ListAllMovies);
            Task<Movie> t2 = new Task<Movie>(() => manager.SearchMovieByName("Good Will Hunting"));

            t1.Start();
            t2.Start();

            await Task.WhenAll(t1, t2);


            return Ok(new { todos = t1.Result, pornome = t2.Result });
        }
    }
}
