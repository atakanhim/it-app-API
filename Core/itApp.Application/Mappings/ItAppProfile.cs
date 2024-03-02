using AutoMapper;
using itApp.Application.DTOs;
using itApp.Application.Features.Commands.Employe.CreateEmploye;
using itApp.Application.Features.Commands.LeaveRequest.CreateLeaveRequest;
using itApp.Application.Features.Commands.LeaveType.CreateLeaveType;
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
            CreateMap<LeaveRequest, LeaveRequestDTO>().ReverseMap();
            CreateMap<LeaveType, LeaveTypeDTO>().ReverseMap();

            // START create EMPLOYEE MAP
            CreateMap<CreateEmployeCommandRequest, Employe>()
                .ForMember(dest => dest.DepartmentId, opt => opt.MapFrom(src => Guid.Parse(src.DepartmentId)));
            
            CreateMap<Employe, CreateEmployeCommandRequest>()
                .ForMember(dest => dest.DepartmentId, opt => opt.MapFrom(src => src.DepartmentId.ToString()));
            // END create EMPLOYEE MAP


            // START create LEAVE REQUEST MAP
            CreateMap<CreateLeaveRequestCommandRequest, LeaveRequest>()
                .ForMember(dest => dest.LeaveTypeId, opt => opt.MapFrom(src => Guid.Parse(src.LeaveTypeId)))
                .ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => Guid.Parse(src.EmployeeId)));
            CreateMap<LeaveRequest, CreateLeaveRequestCommandRequest>()
                .ForMember(dest => dest.LeaveTypeId, opt => opt.MapFrom(src => src.LeaveTypeId.ToString()))
                .ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.EmployeeId.ToString()));
            // END create LEAVE REQUEST MAP

            // START create LeaveType MAP
            CreateMap<LeaveType, CreateLeaveTypeCommandRequest>().ReverseMap();
            // END create LeaveType MAP
        }
    }
}
