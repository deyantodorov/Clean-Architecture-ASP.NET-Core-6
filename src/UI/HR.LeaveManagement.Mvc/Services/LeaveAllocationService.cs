using System;
using System.Threading.Tasks;

using HR.LeaveManagement.Mvc.Contracts;
using HR.LeaveManagement.Mvc.Services.Base;

namespace HR.LeaveManagement.Mvc.Services
{
    public class LeaveAllocationService : BaseHttpService, ILeaveAllocationService
    {
        public LeaveAllocationService(ILocalStorageService localStorage, IClient client)
            : base(localStorage, client)
        {
        }

        public async Task<Response<int>> CreateLeaveAllocations(int leaveTypeId)
        {
            try
            {
                var response = new Response<int>();
                var createLeaveAllocation = new CreateLeaveAllocationDto { LeaveTypeId = leaveTypeId };

                AddBearerToken();

                var apiResponse = await _client.LeaveAllocationsPOSTAsync(createLeaveAllocation);
                if (apiResponse.Success)
                {
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
    }
}
