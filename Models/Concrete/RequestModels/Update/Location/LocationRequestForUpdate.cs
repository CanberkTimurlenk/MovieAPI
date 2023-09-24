using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Concrete.RequestModels.Update.Location
{
    public record LocationRequestForUpdate
    {
        public string Name { get; init; }
    }
}
