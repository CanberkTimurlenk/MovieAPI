using Models.Abstract.Entities;
using Models.Concrete.Entities;
using Repositories.Abstract;
using Repositories.Abstract.Base.EFCore;
using Repositories.Concrete.EFCore.Contexts;

namespace Repositories.Concrete.EFCore
{
    public class AwardTypeRepository : BaseRepository<AwardType>, IAwardTypeRepository
    {
        public AwardTypeRepository(MovieContext context) : base(context)
        {
        }




    }
}
