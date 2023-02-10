using MyProject.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Repositories.Interfaces
{
    public interface IPersonRepository
    {
        Task<List<Person>> GetAllAsync();

        Task<Person> GetByIdAsync(int id);

        Task<Person> AddAsync(string firstName, string lastName, 
            DateTime date, string tz, string sex, string healthFund);

        Task<Person> UpdateAsync(Person person);

        Task DeleteAsync(int id);
    }
}
