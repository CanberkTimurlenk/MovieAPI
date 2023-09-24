using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Concrete.RequestModels.Insertion.Language
{
    public record LanguageRequestForInsertion
    {
        public string Name { get; init; }
    }
}
