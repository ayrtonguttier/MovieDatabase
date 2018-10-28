using System;
using Data.Context;
using Data.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MainTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ContextTest()
        {
            MainContext context = new MainContext("MainConnection");
            MovieRepository repository = new MovieRepository(context);

            var movie = repository.Add(new MovieDomain.Entities.Movie
            {
                Title = "Good Will Hunting"
            });

            repository.Commit();

            Assert.IsNotNull(movie);

        }
    }
}
