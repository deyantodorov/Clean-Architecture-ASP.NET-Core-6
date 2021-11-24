using AutoMapper;

using HR.LeaveManagement.Mvc.Contracts;
using HR.LeaveManagement.Mvc.Models;
using HR.LeaveManagement.Mvc.Services.Base;

namespace HR.LeaveManagement.Mvc.Services
{
    public class LeaveTypeService : BaseHttpService, ILeaveTypeService
    {
        private readonly IMapper _mapper;
        private readonly IClient _client;
        private readonly ILocalStorageService _localStorage;

        public LeaveTypeService(IMapper mapper, IClient client, ILocalStorageService localStorage)
            : base(localStorage, client)
        {
            _mapper = mapper;
            _client = client;
            _localStorage = localStorage;
        }

       
    }
}
