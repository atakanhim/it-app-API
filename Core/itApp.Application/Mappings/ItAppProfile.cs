using AutoMapper;
using itApp.Application.DTOs;
using itApp.Application.DTOs.EmployeeDTOs;
using itApp.Application.DTOs.FromChekMarkToEmployee;
using itApp.Application.Features.Commands.CheckMark.CreateCheckMark;
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
            // DTO
            CreateMap<Employe, EmployeDTOIncludeAll>().ReverseMap();
            CreateMap<Employe, EmployeeDTOIncludeNothing>().ReverseMap();
            CreateMap<Employe, EmployeeDTOIncludeCheckMark>().ReverseMap();
            CreateMap<Employe, EmployeeDTOIncludeLeaveRequest>().ReverseMap();

            CreateMap<LeaveRequest, LeaveRequestDTO>().ReverseMap();
            CreateMap<LeaveType, LeaveTypeDTO>().ReverseMap();
            CreateMap<Department, DepartmentDTO>().ReverseMap();
            CreateMap<CheckMark, CheckMarkDTO>().ReverseMap();
            CreateMap<CheckMark, BaseCheckMarkDTO>().ReverseMap();





            // START create EMPLOYEE MAP
            CreateMap<CreateEmployeCommandRequest, Employe>()
                .ForMember(dest => dest.DepartmentId, opt => opt.MapFrom(src => Guid.Parse(src.DepartmentId)));
            
            CreateMap<Employe, CreateEmployeCommandRequest>()
                .ForMember(dest => dest.DepartmentId, opt => opt.MapFrom(src => src.DepartmentId.ToString()));
            // END create EMPLOYEE MAP


            // START create LEAVE REQUEST MAP
            CreateMap<CreateLeaveRequestCommandRequest, LeaveRequest>()
                .ForMember(dest => dest.LeaveTypeId, opt => opt.MapFrom(src => Guid.Parse(src.LeaveTypeId)))
                .ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => Guid.Parse(src.EmployeeId)))
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate.Date))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate.Date));

            CreateMap<LeaveRequest, CreateLeaveRequestCommandRequest>()
                .ForMember(dest => dest.LeaveTypeId, opt => opt.MapFrom(src => src.LeaveTypeId.ToString()))
                .ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.EmployeeId.ToString()))
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate.Date))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate.Date));
            // END create LEAVE REQUEST MAP

            // START create LeaveType MAP
            CreateMap<LeaveType, CreateLeaveTypeCommandRequest>().ReverseMap();
            // END create LeaveType MAP



            // START create CheckMark REQUEST MAP 
                // requestteki string degeri guid parse etme işlemi
            CreateMap<CreateCheckMarkCommandRequest, CheckMark>()
                .ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => Guid.Parse(src.EmployeeId)))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.StartDate));
                // checkmark entitysindeki requeste tostring etme işlemi
            CreateMap<CheckMark, CreateCheckMarkCommandRequest>()
                .ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.EmployeeId.ToString()));
            // END create CheckMark REQUEST MAP



        }
    }
}
