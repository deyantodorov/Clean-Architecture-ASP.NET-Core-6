using System;

using AutoMapper;

using HR.LeaveManagement.Mvc.Models;
using HR.LeaveManagement.Mvc.Services.Base;

namespace HR.LeaveManagement.Mvc
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateLeaveTypeDto, CreateLeaveTypeVM>().ReverseMap();
            CreateMap<LeaveTypeDto, LeaveTypeVM>().ReverseMap();
        }
    }
}

