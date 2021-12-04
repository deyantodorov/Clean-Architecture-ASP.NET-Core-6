using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public async Task<Response<int>> CreateLeaveType(CreateLeaveTypeVM createLeaveType)
        {
            try
            {
                var response = new Response<int>();
                var createLeaveTypeDto = _mapper.Map<CreateLeaveTypeDto>(createLeaveType);

                AddBearerToken();
                var apiResponse = await _client.LeaveTypesPOSTAsync(createLeaveTypeDto);

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

        public async Task<Response<int>> DeleteLeaveType(int id)
        {
            try
            {
                AddBearerToken();
                await _client.LeaveTypesDELETEAsync(id);
                return new Response<int> { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }

        public async Task<LeaveTypeVM> GetLeaveTypeDetails(int id)
        {
            AddBearerToken();
            var leaveType = await _client.LeaveTypesGETAsync(id);
            return _mapper.Map<LeaveTypeVM>(leaveType);
        }

        public async Task<List<LeaveTypeVM>> GetLeaveTypes()
        {
            AddBearerToken();
            var leaveTypes = await _client.LeaveTypesAllAsync();
            return _mapper.Map<List<LeaveTypeVM>>(leaveTypes);
        }

        public async Task<Response<int>> UpdateLeaveType(int id, LeaveTypeVM leaveType)
        {
            try
            {
                var leaveTypeDto = _mapper.Map<LeaveTypeDto>(leaveType);
                AddBearerToken();
                await _client.LeaveTypesPUTAsync(leaveTypeDto); // TODO: resolve this id
                return new Response<int>() { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }
    }
}
