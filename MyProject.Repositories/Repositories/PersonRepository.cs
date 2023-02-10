using Microsoft.EntityFrameworkCore;
using MyProject.Repositories.Entities;
using MyProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MyProject.Repositories.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        readonly IContext _context;

        public PersonRepository(IContext context)
        {
            _context = context;
        }


        public async Task<Person> AddAsync(string firstName, string lastName, DateTime date, string tz, string sex, string healthFund)
        {
            var newPerson = new Person
            {
                FirstName = firstName,
                LastName = lastName,
                DateOfBirth = date,
                Tz=tz,
                Sex = sex,
                healthFund = healthFund
            };
            await _context.People.AddAsync(newPerson);
            await _context.SaveChangesAsync();
            return newPerson;
        }

        public async Task  DeleteAsync(int id)
        {
            var person = await GetByIdAsync(id);
            _context.People.Remove(person);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Person>> GetAllAsync()
        {
            return await _context.People.ToListAsync();
        }

        public async Task<Person> GetByIdAsync(int id)
        {
            return await _context.People.FindAsync(id);
        }

        public async Task<Person> UpdateAsync(Person person)
        {
            var updatedPerson = _context.People.Update(person);
            await _context.SaveChangesAsync();
            return updatedPerson.Entity;
        }

    }
}
