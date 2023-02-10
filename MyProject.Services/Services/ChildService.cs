using AutoMapper;
using MyProject.Common.DTOs;
using MyProject.Repositories.Entities;
using MyProject.Repositories.Interfaces;
using MyProject.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Services.Services
{
    public class ChildService : IChildService
    {
        private readonly IChildRepository _child;
        private readonly IMapper _mapper;
        public ChildService(IChildRepository child,IMapper mapper) 
        {
            _child= child;
            _mapper= mapper;
        }
        public async Task<ChildDTO> AddAsync(ChildDTO child)
        {
            return _mapper.Map<ChildDTO>(await _child.AddAsync(child.Name,child.DateOfBirth,child.Tz,child.ParentId));
        }

        public async Task DeleteAsync(int id)
        {
            await _child.DeleteAsync(id);
        }

        public async Task<ChildDTO> GetByIdAsync(int id)
        {
            return _mapper.Map<ChildDTO>(await _child.GetByIdAsync(id));
        }

        public async Task<IEnumerable<ChildDTO>> GetListAsync()
        {
            return _mapper.Map<IEnumerable<ChildDTO>>(await _child.GetAllAsync());
        }

        public async Task<ChildDTO> UpdateAsync(ChildDTO child)
        {
            return _mapper.Map<ChildDTO>(await _child.UpdateAsync(_mapper.Map<Child>(child)));
        }
    }
}
