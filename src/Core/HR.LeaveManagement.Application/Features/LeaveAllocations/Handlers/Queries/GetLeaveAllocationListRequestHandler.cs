using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using HR.LeaveManagement.Application.Constants;
using HR.LeaveManagement.Application.Contracts.Identity;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.DTOs.LeaveAllocation;
using HR.LeaveManagement.Application.Features.LeaveAllocations.Requests.Queries;
using HR.LeaveManagement.Domain;

using MediatR;

using Microsoft.AspNetCore.Http;

namespace HR.LeaveManagement.Application.Features.LeaveAllocations.Handlers.Queries
{
    public class GetLeaveAllocationListRequestHandler : IRequestHandler<GetLeaveAllocationListRequest, List<LeaveAllocationDto>>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public GetLeaveAllocationListRequestHandler(
            ILeaveAllocationRepository leaveAllocationRepository,
            IHttpContextAccessor httpContextAccessor,
            IUserService userService,
            IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _httpContextAccessor = httpContextAccessor;
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<List<LeaveAllocationDto>> Handle(GetLeaveAllocationListRequest request, CancellationToken cancellationToken)
        {
            var leaveAllocations = new List<LeaveAllocation>();
            var allocations = new List<LeaveAllocationDto>();

            if (request.IsLoggedInUser)
            {
                var userId = _httpContextAccessor.HttpContext.User.FindFirst(x => x.Type == CustomClaimTypes.Uid)?.Value;
                leaveAllocations = await _leaveAllocationRepository.GetLeaveAllocationsWithDetails(userId);

                var employee = await _userService.GetEmployee(userId);
                allocations = _mapper.Map<List<LeaveAllocationDto>>(leaveAllocations);

                foreach (var allocation in allocations)
                {
                    allocation.Employee = employee;
                }
            }
            else
            {
                leaveAllocations = await _leaveAllocationRepository.GetLeaveAllocationsWithDetails();
                allocations = _mapper.Map<List<LeaveAllocationDto>>(leaveAllocations);

                foreach (var allocation in allocations)
                {
                    allocation.Employee = await _userService.GetEmployee(allocation.EmployeeId);
                }
            }

            return allocations;
        }
    }
}
