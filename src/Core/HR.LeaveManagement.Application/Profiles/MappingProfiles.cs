using AutoMapper;

using HR.LeaveManagement.Application.DTOs.LeaveAllocation;
using HR.LeaveManagement.Application.DTOs.LeaveRequest;
using HR.LeaveManagement.Application.DTOs.LeaveType;
using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<LeaveAllocation, LeaveAllocationDto>().ReverseMap();

            CreateMap<LeaveRequest, LeaveRequestDto>().ReverseMap();

            CreateMap<LeaveRequest, LeaveRequestListDto>().ReverseMap();

            CreateMap<LeaveType, LeaveTypeDto>().ReverseMap();
        }
    }
}
