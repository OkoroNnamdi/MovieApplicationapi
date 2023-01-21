using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieManagement.DataAccess.Context;
using MovieManagement.Domain.Repository;

namespace MovieManagement.DataAccess.Implementation
{
    public  class UnitOfWork:IUnitOfWork
    {
        private readonly MovieManagementContext _context;

        public UnitOfWork( MovieManagementContext context)
        {
            _context = context;
            Actor = new ActorRepository(_context);
            Movie = new MovieRepository(_context);
            Genre = new GenreRepository(_context);
            Biography = new BiographyRepository(_context);
        }
        public IActorRepository Actor { get; private set; }
        public IMovieRepository Movie { get; private set; }
        public IGenreRepository Genre { get; private set; }
        public IBiographyRepository Biography { get; private set; }

        public  async Task < int> saveChangeesAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
