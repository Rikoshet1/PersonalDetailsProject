

namespace MyProject.Repositories.Entities
{
    public class Person
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Id { get; set; }
        public string Tz { get; set; }


        public DateTime DateOfBirth { get; set; }

        public string Sex { get; set; }

        public string healthFund { get; set; }
    }
}