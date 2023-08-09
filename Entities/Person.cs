namespace Entities
{
   
    public class Person
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime BirthDate { get; set; }        
        public string? Description { get; set; }
      
        public List<MovieRole>? MovieRoles { get; set; }

        
    }
}
