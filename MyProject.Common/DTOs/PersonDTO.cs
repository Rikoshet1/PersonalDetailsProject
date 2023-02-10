using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Common.DTOs
{
    public class PersonDTO
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Id { get; set; }

        public string Tz { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Sex { get; set; }

        public string HealthFund { get; set; }
    }
}
