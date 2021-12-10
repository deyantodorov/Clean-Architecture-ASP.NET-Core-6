using AutoMapper;

using HR.LeaveManagement.Mvc.Models.Employee;
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
            CreateMap<CreateLeaveRequestDto, CreateLeaveRequestVm>().ReverseMap();
            CreateMap<LeaveRequestDto, LeaveRequestVm>()
                .ForMember(x => x.DateRequested,
                    opt => opt.MapFrom(x => x.DateRequested.DateTime))
                .ForMember(x => x.StartDate,
                    opt => opt.MapFrom(x => x.StartDate.DateTime))
                .ForMember(x => x.EndDate,
                    opt => opt.MapFrom(x => x.EndDate.DateTime))
                .ReverseMap();
            CreateMap<LeaveRequestListDto, LeaveRequestVm>()
                .ForMember(x => x.DateRequested,
                    opt => opt.MapFrom(x => x.DateRequested.DateTime))
                .ForMember(x => x.StartDate,
                    opt => opt.MapFrom(x => x.StartDate.DateTime))
                .ForMember(x => x.EndDate,
                    opt => opt.MapFrom(x => x.EndDate.DateTime))
                .ReverseMap();
            CreateMap<LeaveTypeDto, LeaveTypeVm>().ReverseMap();
            CreateMap<RegisterVm, RegistrationRequest>().ReverseMap();
            CreateMap<EmployeeVm, Employee>();
        }
    }
}

