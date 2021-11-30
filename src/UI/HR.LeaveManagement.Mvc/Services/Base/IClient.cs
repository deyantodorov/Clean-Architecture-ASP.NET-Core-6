using System.Net.Http;

namespace HR.LeaveManagement.Mvc.Services.Base
{
    public partial interface IClient
    {
       HttpClient HttpClient { get; }
    }
}

