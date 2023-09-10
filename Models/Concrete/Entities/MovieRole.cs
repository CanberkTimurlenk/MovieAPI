﻿using Models.Abstract.Entities;

namespace Models.Concrete.Entities
{
    public class MovieRole : IEntity
    {
        public int Id { get; set; }        
        public ICollection<Person> Persons { get; set; }
        
    }
}
