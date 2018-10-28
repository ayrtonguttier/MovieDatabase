using Data.Context;
using Data.Generics;
using MovieDomain.Entities;
using MovieDomain.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {

        public MovieRepository():this(new MainContext()){}
        public MovieRepository(DbContext context) : base(context) { }

        public Movie GetByMovieTitle(string title)
        {
            return base.dbSet.FirstOrDefault(x => x.Title == title);
        }
    }
}
