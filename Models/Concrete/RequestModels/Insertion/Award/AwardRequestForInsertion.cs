using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Concrete.RequestModels.Insertion.Award
{
    public record AwardRequestForInsertion
    {
        public int AwardTypeId { get; init; }
        public int MovieId { get; init; }
        public DateTime Date { get; init; }
        public string? Description { get; init; }
    }
}
