using AutoMapper;

using HR.LeaveManagement.Mvc.Contracts;
using HR.LeaveManagement.Mvc.Models;
using HR.LeaveManagement.Mvc.Services.Base;

namespace HR.LeaveManagement.Mvc.Services
{
    public class LeaveTypeService : BaseHttpService, ILeaveTypeService
    {
        private readonly IMapper _mapper;

        public LeaveTypeService(IMapper mapper, IClient client, ILocalStorageService localStorage)
            : base(localStorage, client)
        {
            _mapper = mapper;
        }

        public Task<Response<int>> CreateLeaveType(CreateLeaveTypeVM createLeaveType)
        {
            throw new NotImplementedException();
        }

        public Task<LeaveTypeVM> CreateLeaveTypeDetails(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<int>> DeleteLeaveType(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<LeaveTypeVM>> GetLeaveTypes()
        {
            throw new NotImplementedException();
        }

        public Task<Response<int>> UpdateLeaveType(int id, LeaveTypeVM leaveType)
        {
            throw new NotImplementedException();
        }
    }
}
