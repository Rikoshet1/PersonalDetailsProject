using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using MyProject.Repositories.Entities;
using MyProject.Common.DTOs;
using AutoMapper;

namespace MyProject.Services
{
    public class Mapping:Profile
    {
        public Mapping()
        {
            CreateMap<Person, PersonDTO>().ReverseMap();
            CreateMap<Child, ChildDTO>().ReverseMap();

        }
    }
}
