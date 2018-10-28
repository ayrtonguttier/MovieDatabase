using Data.Context;
using Data.Repositories;
using MovieDomain.Repositories;
using Ninject.Modules;
using System.Data.Entity;

namespace DependencyManager
{
    public class MovieModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IMovieRepository>().To<MovieRepository>();            
        }
    }
}
