using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Concrete.RequestModels.Update.Person
{
    public record PersonRequestForUpdate
    {
        public string Firstname { get; init; }
        public string Lastname { get; init; }
        public DateTime BirthDate { get; init; }
        public string? Description { get; init; }
    }
}
