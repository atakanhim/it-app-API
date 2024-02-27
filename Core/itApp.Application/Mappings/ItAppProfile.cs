using AutoMapper;
using itApp.Application.DTOs;
using itApp.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itApp.Application.Mappings
{
    public class ItAppProfile : Profile
    {
        public ItAppProfile()
        {
            CreateMap<Employe, EmployeDTO>().ReverseMap();
        }
    }
}
