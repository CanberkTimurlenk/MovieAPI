using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Abstract.Domains
{
    public interface IEntityWithHasOwnPk
    {
        public int Id { get; set; }
    }
}
