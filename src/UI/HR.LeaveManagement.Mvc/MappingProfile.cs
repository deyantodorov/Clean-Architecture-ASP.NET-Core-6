using AutoMapper;

using HR.LeaveManagement.Mvc.Models.LeaveRequest;
using HR.LeaveManagement.Mvc.Models.LeaveType;
using HR.LeaveManagement.Mvc.Models.User;
using HR.LeaveManagement.Mvc.Services.Base;

namespace HR.LeaveManagement.Mvc
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateLeaveTypeDto, CreateLeaveTypeVm>().ReverseMap();
            CreateMap<LeaveTypeDto, LeaveTypeVm>().ReverseMap();
            CreateMap<RegisterVm, RegistrationRequest>().ReverseMap();
            CreateMap<CreateLeaveRequestDto, CreateLeaveRequestVm>().ReverseMap();
        }
    }
}

