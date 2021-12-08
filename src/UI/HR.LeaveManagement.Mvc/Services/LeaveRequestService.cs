using System;
using System.Threading.Tasks;

using AutoMapper;

using HR.LeaveManagement.Mvc.Contracts;
using HR.LeaveManagement.Mvc.Models.LeaveRequest;
using HR.LeaveManagement.Mvc.Services.Base;

namespace HR.LeaveManagement.Mvc.Services
{
    public class LeaveRequestService : BaseHttpService, ILeaveRequestService
    {
        private readonly IMapper _mapper;

        public LeaveRequestService(ILocalStorageService localStorage, IClient client, IMapper mapper)
            : base(localStorage, client)
        {
            _mapper = mapper;
        }

        public Task<AdminLeaveRequestViewVm> GetAdminLeaveRequestList()
        {
            throw new System.NotImplementedException();
        }

        public Task<EmployeeLeaveRequestViewVm> GetEmployeeLeaveRequest()
        {
            throw new System.NotImplementedException();
        }

        public async Task<Response<int>> CreateLeaveRequest(CreateLeaveRequestVm leaveRequest)
        {
            try
            {
                var response = new Response<int>();
                var createLeaveRequest = _mapper.Map<CreateLeaveRequestDto>(leaveRequest);

                AddBearerToken();

                var apiResponse = await _client.LeaveRequestsPOSTAsync(createLeaveRequest);
                if (apiResponse.Success)
                {
                    response.Data = apiResponse.Id;
                    response.Success = true;
                }
                else
                {
                    foreach (var error in apiResponse.Errors)
                    {
                        response.ValidationErrors += error + Environment.NewLine;
                    }
                }

                return response;
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }

        public Task DeleteLeaveRequest(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<EmployeeLeaveRequestViewVm> GetUserLeaveRequests()
        {
            throw new NotImplementedException();
        }

        public Task<LeaveRequestVm> GetLeaveRequest(int id)
        {
            throw new NotImplementedException();
        }

        public Task ApproveLeaveRequest(int id, bool approved)
        {
            throw new NotImplementedException();
        }
    }
}
