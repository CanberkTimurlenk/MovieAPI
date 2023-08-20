using Microsoft.EntityFrameworkCore;
using Repositories.Abstract;
using Repositories.Concrete.EFCore.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Concrete.EFCore
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly MovieContext _context;
        private readonly IMovieRepository _movieRepository;

        public RepositoryManager(MovieContext context, IMovieRepository movieRepository)    
        {
            _context = context;
            _movieRepository = movieRepository;
            
        }

        public IMovieRepository Movie => _movieRepository;
        
        public async Task SaveAsync() => await _context.SaveChangesAsync();
        
    }
}
