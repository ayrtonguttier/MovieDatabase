using MovieDomain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.EntityConfiguration
{
    public class MovieConfiguration : EntityTypeConfiguration<Movie>
    {
        public MovieConfiguration()
        {
            base.ToTable("Movies");

            base.HasKey(x => x.ID);

            base.Property(x => x.ID)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                .HasColumnName("ID");

            base.Property(x => x.Title)
                .HasColumnName("TITLE");

            base.Property(x => x.Image)
                .HasColumnName("IMAGE");
        }
    }
}
