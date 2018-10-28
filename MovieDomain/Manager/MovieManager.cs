using MovieDomain.Entities;
using MovieDomain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDomain.Manager
{
    public class MovieManager
    {
        IMovieRepository repository;

        public MovieManager(IMovieRepository movieRepository)
        {
            repository = movieRepository;
        }

        public bool DoMovieExist(string title)
        {
            return repository.GetByMovieTitle(title) != null;
        }

        public Movie RegisterNewMovie(Movie movie)
        {
            var result = repository.Add(movie);
            repository.Commit();
            return result;
        }

        public IEnumerable<Movie> ListAllMovies()
        {
            return repository.GetAll();
        }

        public Movie SearchMovieByName(string name)
        {
            return repository.GetByMovieTitle(name);
        }
    }
}
