﻿using Models.Abstract.Entities;

namespace Models.Concrete.Entities
{
    public class Director : MovieRole, IEntity
    {
        public override string ToString()
            
            => nameof(Director);

    }

}