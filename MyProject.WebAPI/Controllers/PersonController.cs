using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyProject.Common.DTOs;
using MyProject.Services.Interfaces;
using MyProject.WebAPI.Models;

namespace MyProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        readonly IPersonService _person;
        public PersonController(IPersonService person)
        {
            _person = person;
        }

        [HttpGet]
        public async Task<IEnumerable<PersonDTO>> Get()
        {
            return await _person.GetListAsync();
        }

        [HttpGet("{id}")]
        public async Task<PersonDTO> GetById(int id)
        {
            return await _person.GetByIdAsync(id);
        }

        [HttpDelete]
        public async Task Delete(int id)
        {
            await _person.DeleteAsync(id);
        }

        [HttpPost]
        public async Task Post([FromBody] PersonModel person)
        {
            await _person.AddAsync(new PersonDTO
            { 
                FirstName = person.FirstName,
                LastName = person.LastName,
                Tz=person.Tz,
                DateOfBirth = person.DateOfBirth,
                Sex = person.Sex, 
                HealthFund = person.HealthFund 
            });

        }

        [HttpPut]
        public async Task Put(PersonDTO person)
        {
            await _person.UpdateAsync(person);
        }
    }
}
