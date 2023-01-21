using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieManagement.Domain.Entites;

namespace MovieManagement.DataAccess.Context
{
    public  class MovieManagementContext:DbContext
    {
        public MovieManagementContext(DbContextOptions<MovieManagementContext>options ):base(options)
        {

        }
        public DbSet <Actor> actors { get; set; }
        public DbSet <Movie> movies { get; set; }
        public DbSet <Genre > genres { get; set; }
        public DbSet<Biography> biographies { get; set; }

        protected  override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor>().HasData(

                new Actor { Id = 1, FirstName = "Ifeanyi", LastName = "Madu",IsDeleted =false  },
                new Actor { Id = 2, FirstName = "Edeh", LastName = "Chinyere",IsDeleted =false  },
                new Actor { Id = 3, FirstName = "Akah", LastName = "Emeka",IsDeleted =false  }
                );
            modelBuilder.Entity<Movie>().HasData(
                new Movie { Id = 1, Name = "The lord is coming ", Description = "The coming of our lord jesus", ActorId = 1,IsDeleted =false },
                 new Movie { Id = 2, Name = "The lord is great ", Description = "The lord jesus is the lord", ActorId = 2 , IsDeleted = false },
                  new Movie { Id = 3, Name = "The lord is good ", Description = "Who is like him", ActorId = 1 , IsDeleted = false },
                   new Movie { Id = 4, Name = "Offering the lord ", Description = "The giver of life presentaion", ActorId = 3,IsDeleted =false  }

                );
        }
        public  override async Task <int>  SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                var entity = entry.Entity;
                if (entry.State == EntityState.Deleted)
                {
                    entry.State = EntityState.Modified;
                    entity.GetType().GetProperty("IsDeleted").SetValue(entity, true);
                }
            }
            int result = await base.SaveChangesAsync();
            return result;
         //  return await base.SaveChangesAsyc(cancellationToken).ConfigureAwait(false);
        }

    }
}
