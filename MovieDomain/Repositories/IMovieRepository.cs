namespace MovieDomain.Repositories
{
    public interface IMovieRepository : Generics.IRepository<Entities.Movie>
    {
        Entities.Movie GetByMovieTitle(string title);
    }
}
