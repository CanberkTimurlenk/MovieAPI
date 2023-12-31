﻿using Models.Abstract.Domains;
using Models.Abstract.Entities;
using Models.Concrete.Domains.Junctions;
using Models.Concrete.Entities.Junctions;

namespace Models.Concrete.Entities
{
    public class Genre : IEntity,IEntityWithHasOwnPk
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<MovieGenre> Movies { get; set; }
        public ICollection<PersonGenre>? Persons { get; set; }
    }
}
