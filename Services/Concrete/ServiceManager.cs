using Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Concrete
{
    public class ServiceManager : IServiceManager
    {
        private readonly IMovieService _movieService;

        public ServiceManager(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public IMovieService MovieService => _movieService;

    }
}
