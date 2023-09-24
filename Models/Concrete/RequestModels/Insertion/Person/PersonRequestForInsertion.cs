using Models.Concrete.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Concrete.RequestModels.Insertion.Person
{
    public record PersonRequestForInsertion
    {
        public string Firstname { get; init; }
        public string Lastname { get; init; }
        public DateTime BirthDate { get; init; }
        public string? Description { get; init; }

        public Actor? Actor { get; init; }
        public Director? Director { get; init; }
    }
}
