using Models.Concrete.Entities;
using Repositories.Abstract;
using Repositories.Abstract.Base.EFCore;
using Repositories.Concrete.EFCore.Contexts;

namespace Repositories.Concrete.EFCore
{
    public class AwardRepository : BaseRepository<Award>, IAwardRepository
    {
        public AwardRepository(MovieContext context) : base(context)
        {

        }

    }
}
