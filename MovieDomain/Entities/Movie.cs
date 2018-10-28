namespace MovieDomain.Entities
{
    public class Movie: Generics.Entity
    {
        public string Title { get; set; }
        public byte[] Image { get; set; }
    }
}
