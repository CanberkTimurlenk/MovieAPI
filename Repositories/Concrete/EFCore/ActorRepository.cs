using Models.Concrete.Entities;
using Repositories.Abstract;
using Repositories.Abstract.Base.EFCore;
using Repositories.Concrete.EFCore.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Concrete.EFCore
{
    public class ActorRepository : BaseRepository<Actor>, IActorRepository
    {
        public ActorRepository(MovieContext context) : base(context)
        {

        }




    }
}
