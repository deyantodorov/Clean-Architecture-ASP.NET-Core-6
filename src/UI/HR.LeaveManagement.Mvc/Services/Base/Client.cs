using System.Net.Http;

namespace HR.LeaveManagement.Mvc.Services.Base
{
    public partial class Client : IClient
    {
        public HttpClient HttpClient => _httpClient;
    }
}

