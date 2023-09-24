using Models.Concrete.Entities;
using Repositories.Abstract;
using Repositories.Abstract.Base.EFCore;
using Repositories.Concrete.EFCore.Contexts;

namespace Repositories.Concrete.EFCore
{
    public class DirectorRepository : BaseRepository<Director>, IDirectorRepository 
    {
        public DirectorRepository(MovieContext context) : base(context)
        {

        }
    }
}
