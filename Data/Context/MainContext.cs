using System.Data.Entity;

namespace Data.Context
{
    public class MainContext : DbContext
    {
        public MainContext() : base("MainConnection") {}
        public MainContext(string nameOrConnectionString) : base(nameOrConnectionString){}
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            base.Configuration.LazyLoadingEnabled = false;
            modelBuilder.Configurations.Add(new EntityConfiguration.MovieConfiguration());
        }

    }
}
