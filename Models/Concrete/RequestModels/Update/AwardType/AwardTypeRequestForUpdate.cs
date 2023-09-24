using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Concrete.RequestModels.Update.AwardType
{
    public record AwardTypeRequestForUpdate
    {
        public string Name { get; init; }
        public string Description { get; init; }
    }
}
