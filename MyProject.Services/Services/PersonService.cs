using AutoMapper;
using MyProject.Common.DTOs;
using MyProject.Repositories.Entities;
using MyProject.Repositories.Interfaces;
using MyProject.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Services.Services
{
    public class PersonService : IPersonService
    {

        private readonly IPersonRepository _person;
        private readonly IMapper _mapper;
        public PersonService(IPersonRepository person, IMapper mapper)
        {
            _person = person;
            _mapper = mapper;
        }
        public async Task<PersonDTO> AddAsync(PersonDTO person)
        {
            return _mapper.Map<PersonDTO>(await _person.AddAsync(person.FirstName,person.LastName,person.DateOfBirth,person.Tz,person.Sex,person.HealthFund));
        }
        public async Task DeleteAsync(int id)
        {
            await _person.DeleteAsync(id);
        }
        public async Task<PersonDTO> GetByIdAsync(int id)
        {
            return _mapper.Map<PersonDTO>(await _person.GetByIdAsync(id));
        }
        public async Task<IEnumerable<PersonDTO>> GetListAsync()
        {
            return _mapper.Map<IEnumerable<PersonDTO>>(await _person.GetAllAsync());
        }

        public async Task<PersonDTO> UpdateAsync(PersonDTO person)
        {
            return _mapper.Map<PersonDTO>(await _person.UpdateAsync(_mapper.Map<Person>(person)));
        }
    }
}
