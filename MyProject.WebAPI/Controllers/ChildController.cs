using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyProject.Common.DTOs;
using MyProject.Services.Interfaces;
using MyProject.WebAPI.Models;

namespace MyProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChildController : ControllerBase
    {
        readonly IChildService _child;
        public ChildController(IChildService child)
        {
            _child = child;
        }
       
        [HttpGet]
        public async Task<IEnumerable<ChildDTO>> Get()
        {
            return await _child.GetListAsync();
        }
       
        [HttpGet("{id}")]
        public async Task<ChildDTO> GetById(int id)
        {
            return await _child.GetByIdAsync(id);
        }
      
        [HttpDelete]
        public async Task Delete(int id)
        {
            await _child.DeleteAsync(id);
        }
      
        [HttpPost]
        public async Task Post([FromBody] ChildModel child)
        {
            await _child.AddAsync(new ChildDTO
            {
                Name = child.Name,
                Tz = child.Tz ,
                DateOfBirth = child.DateOfBirth,
                ParentId = child.ParentId
            });

        }
      
        [HttpPut]
        public async Task Put(int id,[FromBody] ChildModel child)
        {
            await _child.UpdateAsync(new ChildDTO { Id=id,Name=child.Name,DateOfBirth=child.DateOfBirth,ParentId=child.ParentId,Tz=child.Tz});
        }
    }
}
