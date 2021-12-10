using System;
using System.Collections.Generic;
using System.Linq;
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

        public LeaveRequestService(
            ILocalStorageService localStorage,
            IClient client,
            IMapper mapper)
            : base(localStorage, client)
        {
            _mapper = mapper;
        }

        public async Task<AdminLeaveRequestViewVm> GetAdminLeaveRequestList()
        {
            AddBearerToken();

            var leaveRequests = await _client.LeaveRequestsAllAsync(isLoggedInUser: false);

            var model = new AdminLeaveRequestViewVm()
            {
                TotalRequests = leaveRequests.Count,
                ApprovedRequests = leaveRequests.Count(x => x.Approve == true),
                PendingRequests = leaveRequests.Count(x => x.Approve == null),
                RejectedRequests = leaveRequests.Count(x => x.Approve == false),
                LeaveRequests = _mapper.Map<List<LeaveRequestVm>>(leaveRequests),
            };

            return model;
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

        public async Task<LeaveRequestVm> GetLeaveRequest(int id)
        {
            AddBearerToken();
            var leaveRequest = await _client.LeaveRequestsGETAsync(id);
            return _mapper.Map<LeaveRequestVm>(leaveRequest);
        }

        public async Task ApproveLeaveRequest(int id, bool approved)
        {
            AddBearerToken();

            try
            {
                var request = new ChangeLeaveRequestApprovalDto { Approved = approved, Id = id };
                await _client.ChangeapprovalAsync(id, request);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
