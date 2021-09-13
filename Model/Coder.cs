namespace SQLLite_Database.Model
{
    public class Coder
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdNumber { get; set; }
        public string Description { get; set; }
            
    }

    public class EmailDelete {
        public string IdNumber { get; set; }
        public string Email { get; set; }
    }
}